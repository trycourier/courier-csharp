using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Services.Notifications.Checks;
using Courier.Services.Notifications.Draft;
using Notifications = Courier.Models.Notifications;

namespace Courier.Services.Notifications;

public interface INotificationService
{
    INotificationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDraftService Draft { get; }

    ICheckService Checks { get; }

    Task<Notifications::NotificationListResponse> List(
        Notifications::NotificationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<Notifications::NotificationGetContent> RetrieveContent(
        Notifications::NotificationRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );
}
