using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Services;

namespace Courier;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICourierClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    bool ResponseValidation { get; init; }

    int? MaxRetries { get; init; }

    TimeSpan? Timeout { get; init; }

    string APIKey { get; init; }

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

    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
