using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Services.Notifications.Checks;
using Courier.Services.Notifications.Draft;
using Notifications = Courier.Models.Notifications;

namespace Courier.Services.Notifications;

public sealed class NotificationService : INotificationService
{
    public INotificationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NotificationService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public NotificationService(ICourierClient client)
    {
        _client = client;
        _draft = new(() => new DraftService(client));
        _checks = new(() => new CheckService(client));
    }

    readonly Lazy<IDraftService> _draft;
    public IDraftService Draft
    {
        get { return _draft.Value; }
    }

    readonly Lazy<ICheckService> _checks;
    public ICheckService Checks
    {
        get { return _checks.Value; }
    }

    public async Task<Notifications::NotificationListResponse> List(
        Notifications::NotificationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Notifications::NotificationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var notifications = await response
            .Deserialize<Notifications::NotificationListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            notifications.Validate();
        }
        return notifications;
    }

    public async Task<Notifications::NotificationGetContent> RetrieveContent(
        Notifications::NotificationRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Notifications::NotificationRetrieveContentParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var notificationGetContent = await response
            .Deserialize<Notifications::NotificationGetContent>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            notificationGetContent.Validate();
        }
        return notificationGetContent;
    }
}
