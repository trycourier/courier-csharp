using System;
using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
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

public interface ICourierClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    bool ResponseValidation { get; init; }

    TimeSpan Timeout { get; init; }

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

    Task<HttpResponse> Execute<T>(HttpRequest<T> request)
        where T : ParamsBase;
}
