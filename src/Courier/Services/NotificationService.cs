using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Notifications;
using Courier.Services.Notifications;

namespace Courier.Services;

/// <inheritdoc />
public sealed class NotificationService : INotificationService
{
    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public async Task<NotificationListResponse> List(
        NotificationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NotificationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var notifications = await response
            .Deserialize<NotificationListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            notifications.Validate();
        }
        return notifications;
    }

    /// <inheritdoc/>
    public async Task<NotificationGetContent> RetrieveContent(
        NotificationRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<NotificationRetrieveContentParams> request = new()
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

    /// <inheritdoc/>
    public async Task<NotificationGetContent> RetrieveContent(
        string id,
        NotificationRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.RetrieveContent(parameters with { ID = id }, cancellationToken);
    }
}
