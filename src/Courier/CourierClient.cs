using System;
using System.Net.Http;
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
    public HttpClient HttpClient { get; init; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(Environment.GetEnvironmentVariable("COURIER_BASE_URL") ?? "https://api.courier.com")
    );
    public Uri BaseUrl
    {
        get { return _baseUrl.Value; }
        init { _baseUrl = new(() => value); }
    }

    Lazy<string> _apiKey = new(() =>
        Environment.GetEnvironmentVariable("COURIER_API_KEY")
        ?? throw new CourierInvalidDataException(
            string.Format("{0} cannot be null", nameof(APIKey)),
            new ArgumentNullException(nameof(APIKey))
        )
    );
    public string APIKey
    {
        get { return _apiKey.Value; }
        init { _apiKey = new(() => value); }
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

    public async Task<HttpResponse> Execute<T>(HttpRequest<T> request)
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(request.Method, request.Params.Url(this))
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this);
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e1)
        {
            throw new CourierIOException("I/O exception", e1);
        }
        if (!responseMessage.IsSuccessStatusCode)
        {
            try
            {
                throw CourierExceptionFactory.CreateApiException(
                    responseMessage.StatusCode,
                    await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false)
                );
            }
            catch (HttpRequestException e)
            {
                throw new CourierIOException("I/O Exception", e);
            }
            finally
            {
                responseMessage.Dispose();
            }
        }
        return new() { Message = responseMessage };
    }

    public CourierClient()
    {
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
}
