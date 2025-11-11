using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Notifications;
using Courier.Models.Notifications.Draft;

namespace Courier.Services.Notifications.Draft;

public sealed class DraftService : IDraftService
{
    public IDraftService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DraftService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public DraftService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<NotificationGetContent> RetrieveContent(
        DraftRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DraftRetrieveContentParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var notificationGetContent = await response
            .Deserialize<NotificationGetContent>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            notificationGetContent.Validate();
        }
        return notificationGetContent;
    }
}
