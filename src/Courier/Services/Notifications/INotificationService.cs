using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Notifications;
using Courier.Services.Notifications.Checks;
using Courier.Services.Notifications.Draft;

namespace Courier.Services.Notifications;

public interface INotificationService
{
    INotificationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDraftService Draft { get; }

    ICheckService Checks { get; }

    Task<NotificationListResponse> List(
        NotificationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<NotificationGetContent> RetrieveContent(
        NotificationRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );
}
