using System;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Notifications.Checks;

namespace Courier.Services.Notifications.Checks;

public interface ICheckService
{
    ICheckService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<CheckUpdateResponse> Update(CheckUpdateParams parameters);

    Task<CheckListResponse> List(CheckListParams parameters);

    Task Delete(CheckDeleteParams parameters);
}
