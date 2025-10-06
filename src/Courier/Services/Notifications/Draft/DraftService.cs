using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Notifications;
using Courier.Models.Notifications.Draft;

namespace Courier.Services.Notifications.Draft;

public sealed class DraftService : IDraftService
{
    readonly ICourierClient _client;

    public DraftService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<NotificationContent> RetrieveContent(DraftRetrieveContentParams parameters)
    {
        HttpRequest<DraftRetrieveContentParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<NotificationContent>().ConfigureAwait(false);
    }
}
