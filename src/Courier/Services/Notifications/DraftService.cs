using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Notifications;
using Courier.Models.Notifications.Draft;

namespace Courier.Services.Notifications;

/// <inheritdoc/>
public sealed class DraftService : IDraftService
{
    /// <inheritdoc/>
    public IDraftService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DraftService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public DraftService(ICourierClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<NotificationGetContent> RetrieveContent(
        DraftRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

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

    /// <inheritdoc/>
    public async Task<NotificationGetContent> RetrieveContent(
        string id,
        DraftRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.RetrieveContent(parameters with { ID = id }, cancellationToken);
    }
}
