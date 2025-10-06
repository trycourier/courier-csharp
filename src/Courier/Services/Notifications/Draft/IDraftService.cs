using System.Threading.Tasks;
using Courier.Models.Notifications;
using Courier.Models.Notifications.Draft;

namespace Courier.Services.Notifications.Draft;

public interface IDraftService
{
    Task<NotificationContent> RetrieveContent(DraftRetrieveContentParams parameters);
}
