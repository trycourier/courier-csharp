using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Services.Audiences;
using Courier.Services.AuditEvents;
using Courier.Services.Auth;
using Courier.Services.Automations;
using Courier.Services.Brands;
using Courier.Services.Bulk;
using Courier.Services.Inbound;
using Courier.Services.Lists;
using Courier.Services.Messages;
using Courier.Services.Notifications;
using Courier.Services.Profiles;
using Courier.Services.Requests;
using Courier.Services.Send;
using Courier.Services.Tenants;
using Courier.Services.Translations;
using Courier.Services.Users;

namespace Courier;

public sealed class CourierClient : ICourierClient
{
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }

    readonly ClientOptions _options;

    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    public Uri BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    public TimeSpan Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    public int MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    public string APIKey
    {
        get { return this._options.APIKey; }
        init { this._options.APIKey = value; }
    }

    public ICourierClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CourierClient(modifier(this._options));
    }

    readonly Lazy<ISendService> _send;
    public ISendService Send
    {
        get { return _send.Value; }
    }

    readonly Lazy<IAudienceService> _audiences;
    public IAudienceService Audiences
    {
        get { return _audiences.Value; }
    }

    readonly Lazy<IAuditEventService> _auditEvents;
    public IAuditEventService AuditEvents
    {
        get { return _auditEvents.Value; }
    }

    readonly Lazy<IAuthService> _auth;
    public IAuthService Auth
    {
        get { return _auth.Value; }
    }

    readonly Lazy<IAutomationService> _automations;
    public IAutomationService Automations
    {
        get { return _automations.Value; }
    }

    readonly Lazy<IBrandService> _brands;
    public IBrandService Brands
    {
        get { return _brands.Value; }
    }

    readonly Lazy<IBulkService> _bulk;
    public IBulkService Bulk
    {
        get { return _bulk.Value; }
    }

    readonly Lazy<IInboundService> _inbound;
    public IInboundService Inbound
    {
        get { return _inbound.Value; }
    }

    readonly Lazy<IListService> _lists;
    public IListService Lists
    {
        get { return _lists.Value; }
    }

    readonly Lazy<IMessageService> _messages;
    public IMessageService Messages
    {
        get { return _messages.Value; }
    }

    readonly Lazy<IRequestService> _requests;
    public IRequestService Requests
    {
        get { return _requests.Value; }
    }

    readonly Lazy<INotificationService> _notifications;
    public INotificationService Notifications
    {
        get { return _notifications.Value; }
    }

    readonly Lazy<IProfileService> _profiles;
    public IProfileService Profiles
    {
        get { return _profiles.Value; }
    }

    readonly Lazy<ITenantService> _tenants;
    public ITenantService Tenants
    {
        get { return _tenants.Value; }
    }

    readonly Lazy<ITranslationService> _translations;
    public ITranslationService Translations
    {
        get { return _translations.Value; }
    }

    readonly Lazy<IUserService> _users;
    public IUserService Users
    {
        get { return _users.Value; }
    }

    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        if (this.MaxRetries <= 0)
        {
            return await ExecuteOnce(request, cancellationToken).ConfigureAwait(false);
        }

        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > this.MaxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > this.MaxRetries || !ShouldRetry(response)))
            {
                if (response.Message.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw CourierExceptionFactory.CreateApiException(
                        response.Message.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new CourierIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(request.Method, request.Params.Url(this))
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this);
        using CancellationTokenSource timeoutCts = new(this.Timeout);
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new CourierIOException("I/O exception", e);
        }
        return new() { Message = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (apiBackoff != null && apiBackoff < TimeSpan.FromMinutes(1))
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.Message.Headers.TryGetValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue.AsSpan(), out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.Message.Headers.TryGetValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue.AsSpan(), out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue.AsSpan(), out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.Message.Headers.TryGetValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return response.Message.StatusCode switch
        {
            // Retry on request timeouts
            HttpStatusCode.RequestTimeout
            or
            // Retry on lock timeouts
            HttpStatusCode.Conflict
            or
            // Retry on rate limits
            HttpStatusCode.TooManyRequests
            or
            // Retry internal errors
            >= HttpStatusCode.InternalServerError => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is CourierIOException;
    }

    public CourierClient()
    {
        _options = new();

        _send = new(() => new SendService(this));
        _audiences = new(() => new AudienceService(this));
        _auditEvents = new(() => new AuditEventService(this));
        _auth = new(() => new AuthService(this));
        _automations = new(() => new AutomationService(this));
        _brands = new(() => new BrandService(this));
        _bulk = new(() => new BulkService(this));
        _inbound = new(() => new InboundService(this));
        _lists = new(() => new ListService(this));
        _messages = new(() => new MessageService(this));
        _requests = new(() => new RequestService(this));
        _notifications = new(() => new NotificationService(this));
        _profiles = new(() => new ProfileService(this));
        _tenants = new(() => new TenantService(this));
        _translations = new(() => new TranslationService(this));
        _users = new(() => new UserService(this));
    }

    public CourierClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
