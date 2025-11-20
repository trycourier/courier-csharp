using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Notifications;
using Courier.Models.Notifications.Draft;

namespace Courier.Services.Notifications;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDraftService
{
    IDraftService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<NotificationGetContent> RetrieveContent(
        DraftRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );
    Task<NotificationGetContent> RetrieveContent(
        string id,
        DraftRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
