using System.Threading.Tasks;
using Courier.Models.Notifications;
using Courier.Services.Notifications.Checks;
using Courier.Services.Notifications.Draft;

namespace Courier.Services.Notifications;

public interface INotificationService
{
    IDraftService Draft { get; }

    ICheckService Checks { get; }

    Task<NotificationListResponse> List(NotificationListParams? parameters = null);

    Task<NotificationGetContent> RetrieveContent(NotificationRetrieveContentParams parameters);
}
