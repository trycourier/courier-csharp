using System.Threading.Tasks;
using Courier.Models;
using Courier.Models.Notifications.Draft;

namespace Courier.Services.Notifications.Draft;

public interface IDraftService
{
    Task<NotificationGetContent> RetrieveContent(DraftRetrieveContentParams parameters);
}
