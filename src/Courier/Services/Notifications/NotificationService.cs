using System;
using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Notifications;
using Courier.Services.Notifications.Checks;
using Courier.Services.Notifications.Draft;

namespace Courier.Services.Notifications;

public sealed class NotificationService : INotificationService
{
    readonly ICourierClient _client;

    public NotificationService(ICourierClient client)
    {
        _client = client;
        _checks = new(() => new CheckService(client));
        _draft = new(() => new DraftService(client));
    }

    readonly Lazy<ICheckService> _checks;
    public ICheckService Checks
    {
        get { return _checks.Value; }
    }

    readonly Lazy<IDraftService> _draft;
    public IDraftService Draft
    {
        get { return _draft.Value; }
    }

    public async Task<NotificationListResponse> List(NotificationListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<NotificationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<NotificationListResponse>().ConfigureAwait(false);
    }

    public async Task<NotificationContent> RetrieveContent(
        NotificationRetrieveContentParams parameters
    )
    {
        HttpRequest<NotificationRetrieveContentParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<NotificationContent>().ConfigureAwait(false);
    }
}
