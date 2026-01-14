using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Lists;
using Courier.Services.Lists;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class ListService : IListService
{
    readonly Lazy<IListServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IListServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IListService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ListService(this._client.WithOptions(modifier));
    }

    public ListService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ListServiceWithRawResponse(client.WithRawResponse));
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
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionList> Retrieve(
        string listID,
        ListRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ListID = listID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Update(ListUpdateParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string listID,
        ListUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with { ListID = listID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ListListResponse> List(
        ListListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(ListDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string listID,
        ListDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ListID = listID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Restore(ListRestoreParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Restore(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Restore(
        string listID,
        ListRestoreParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Restore(parameters with { ListID = listID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ListServiceWithRawResponse : IListServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IListServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ListServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ListServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;

        _subscriptions = new(() => new SubscriptionServiceWithRawResponse(client));
    }

    readonly Lazy<ISubscriptionServiceWithRawResponse> _subscriptions;
    public ISubscriptionServiceWithRawResponse Subscriptions
    {
        get { return _subscriptions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionList>> Retrieve(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscriptionList = await response
                    .Deserialize<SubscriptionList>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscriptionList.Validate();
                }
                return subscriptionList;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionList>> Retrieve(
        string listID,
        ListRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ListID = listID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string listID,
        ListUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ListID = listID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ListListResponse>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var lists = await response
                    .Deserialize<ListListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    lists.Validate();
                }
                return lists;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string listID,
        ListDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ListID = listID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Restore(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Restore(
        string listID,
        ListRestoreParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Restore(parameters with { ListID = listID }, cancellationToken);
    }
}
