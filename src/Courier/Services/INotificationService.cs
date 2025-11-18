using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Notifications;
using Courier.Services.Notifications;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
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
