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
    readonly Lazy<IItemServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IItemServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ItemService(this._client.WithOptions(modifier));
    }

    public ItemService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ItemServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Update(ItemUpdateParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string topicID,
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with { TopicID = topicID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(ItemDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string topicID,
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { TopicID = topicID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ItemServiceWithRawResponse : IItemServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IItemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ItemServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ItemServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string topicID,
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { TopicID = topicID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string topicID,
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { TopicID = topicID }, cancellationToken);
    }
}
