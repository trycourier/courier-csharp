using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Tenants.Preferences.Items;

namespace Courier.Services.Tenants.Preferences;

/// <inheritdoc/>
public sealed class ItemService : IItemService
{
    /// <inheritdoc/>
    public IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ItemService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public ItemService(ICourierClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task Update(
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TopicID == null)
        {
            throw new CourierInvalidDataException("'parameters.TopicID' cannot be null");
        }

        HttpRequest<ItemUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Update(
        string topicID,
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with { TopicID = topicID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TopicID == null)
        {
            throw new CourierInvalidDataException("'parameters.TopicID' cannot be null");
        }

        HttpRequest<ItemDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string topicID,
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { TopicID = topicID }, cancellationToken);
    }
}
