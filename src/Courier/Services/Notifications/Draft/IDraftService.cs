using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Notifications.Draft;
using Notifications = Courier.Models.Notifications;

namespace Courier.Services.Notifications.Draft;

public interface IDraftService
{
    IDraftService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<Notifications::NotificationGetContent> RetrieveContent(
        DraftRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );
}
