using System.Threading.Tasks;
using Courier.Models.Notifications;
using Courier.Services.Notifications.Checks;
using Courier.Services.Notifications.Draft;

namespace Courier.Services.Notifications;

public interface INotificationService
{
    ICheckService Checks { get; }

    IDraftService Draft { get; }

    Task<NotificationListResponse> List(NotificationListParams? parameters = null);

    Task<NotificationContent> RetrieveContent(NotificationRetrieveContentParams parameters);
}
