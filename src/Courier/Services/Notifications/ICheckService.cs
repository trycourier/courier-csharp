using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Notifications.Checks;

namespace Courier.Services.Notifications;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICheckService
{
    ICheckService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<CheckUpdateResponse> Update(
        CheckUpdateParams parameters,
        CancellationToken cancellationToken = default
    );
    Task<CheckUpdateResponse> Update(
        string submissionID,
        CheckUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<CheckListResponse> List(
        CheckListParams parameters,
        CancellationToken cancellationToken = default
    );
    Task<CheckListResponse> List(
        string submissionID,
        CheckListParams parameters,
        CancellationToken cancellationToken = default
    );

    Task Delete(CheckDeleteParams parameters, CancellationToken cancellationToken = default);
    Task Delete(
        string submissionID,
        CheckDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
