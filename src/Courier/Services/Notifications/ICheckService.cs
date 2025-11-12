using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Notifications.Checks;

namespace Courier.Services.Notifications;

public interface ICheckService
{
    ICheckService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<CheckUpdateResponse> Update(
        CheckUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<CheckListResponse> List(
        CheckListParams parameters,
        CancellationToken cancellationToken = default
    );

    Task Delete(CheckDeleteParams parameters, CancellationToken cancellationToken = default);
}
