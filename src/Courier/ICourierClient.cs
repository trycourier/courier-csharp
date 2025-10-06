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

    string APIKey { get; init; }

    ISendService Send { get; }

    ITenantService Tenants { get; }

    IAudienceService Audiences { get; }

    IBulkService Bulk { get; }

    IUserService Users { get; }

    IAuditEventService AuditEvents { get; }

    IAutomationService Automations { get; }

    IBrandService Brands { get; }

    IListService Lists { get; }

    IMessageService Messages { get; }

    INotificationService Notifications { get; }

    IAuthService Auth { get; }

    IInboundService Inbound { get; }

    IRequestService Requests { get; }

    IProfileService Profiles { get; }

    ITranslationService Translations { get; }

    Task<HttpResponse> Execute<T>(HttpRequest<T> request)
        where T : ParamsBase;
}
