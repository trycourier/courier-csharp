using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Lists;
using Courier.Services.Lists;

namespace Courier.Services;

/// <inheritdoc />
public sealed class ListService : IListService
{
    /// <inheritdoc/>
    public IListService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ListService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public ListService(ICourierClient client)
    {
        _client = client;
        _subscriptions = new(() => new SubscriptionService(client));
    }

    readonly Lazy<ISubscriptionService> _subscriptions;
    public ISubscriptionService Subscriptions
    {
        get { return _subscriptions.Value; }
    }

    /// <inheritdoc/>
    public async Task<SubscriptionList> Retrieve(
        ListRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ListID == null)
        {
            throw new CourierInvalidDataException("'parameters.ListID' cannot be null");
        }

        HttpRequest<ListRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var subscriptionList = await response
            .Deserialize<SubscriptionList>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            subscriptionList.Validate();
        }
        return subscriptionList;
    }

    /// <inheritdoc/>
    public async Task<SubscriptionList> Retrieve(
        string listID,
        ListRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { ListID = listID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        ListUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ListID == null)
        {
            throw new CourierInvalidDataException("'parameters.ListID' cannot be null");
        }

        HttpRequest<ListUpdateParams> request = new()
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
        string listID,
        ListUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with { ListID = listID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ListListResponse> List(
        ListListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ListListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var lists = await response
            .Deserialize<ListListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            lists.Validate();
        }
        return lists;
    }

    /// <inheritdoc/>
    public async Task Delete(
        ListDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ListID == null)
        {
            throw new CourierInvalidDataException("'parameters.ListID' cannot be null");
        }

        HttpRequest<ListDeleteParams> request = new()
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
        string listID,
        ListDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ListID = listID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Restore(
        ListRestoreParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ListID == null)
        {
            throw new CourierInvalidDataException("'parameters.ListID' cannot be null");
        }

        HttpRequest<ListRestoreParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Restore(
        string listID,
        ListRestoreParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Restore(parameters with { ListID = listID }, cancellationToken);
    }
}
