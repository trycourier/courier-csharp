using System.Threading.Tasks;
using Courier.Models.Notifications.Checks;

namespace Courier.Services.Notifications.Checks;

public interface ICheckService
{
    Task<CheckUpdateResponse> Update(CheckUpdateParams parameters);

    Task<CheckListResponse> List(CheckListParams parameters);

    Task Delete(CheckDeleteParams parameters);
}
