using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Services;

namespace Courier;

/// <summary>
/// A client for interacting with the Courier REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICourierClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICourierClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICourierClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISendService Send { get; }

    IAudienceService Audiences { get; }

    IAuditEventService AuditEvents { get; }

    IAuthService Auth { get; }

    IAutomationService Automations { get; }

    IBrandService Brands { get; }

    IBulkService Bulk { get; }

    IInboundService Inbound { get; }

    IListService Lists { get; }

    IMessageService Messages { get; }

    IRequestService Requests { get; }

    INotificationService Notifications { get; }

    IProfileService Profiles { get; }

    ITenantService Tenants { get; }

    ITranslationService Translations { get; }

    IUserService Users { get; }
}

/// <summary>
/// A view of <see cref="ICourierClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface ICourierClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICourierClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISendServiceWithRawResponse Send { get; }

    IAudienceServiceWithRawResponse Audiences { get; }

    IAuditEventServiceWithRawResponse AuditEvents { get; }

    IAuthServiceWithRawResponse Auth { get; }

    IAutomationServiceWithRawResponse Automations { get; }

    IBrandServiceWithRawResponse Brands { get; }

    IBulkServiceWithRawResponse Bulk { get; }

    IInboundServiceWithRawResponse Inbound { get; }

    IListServiceWithRawResponse Lists { get; }

    IMessageServiceWithRawResponse Messages { get; }

    IRequestServiceWithRawResponse Requests { get; }

    INotificationServiceWithRawResponse Notifications { get; }

    IProfileServiceWithRawResponse Profiles { get; }

    ITenantServiceWithRawResponse Tenants { get; }

    ITranslationServiceWithRawResponse Translations { get; }

    IUserServiceWithRawResponse Users { get; }

    /// <summary>
    /// Sends a request to the Courier REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
