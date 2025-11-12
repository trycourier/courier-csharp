using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Lists;
using Courier.Services.Lists;

namespace Courier.Services;

public sealed class ListService : IListService
{
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

    public async Task<SubscriptionList> Retrieve(
        ListRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task Update(
        ListUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ListUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

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

    public async Task Delete(
        ListDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ListDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task Restore(
        ListRestoreParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ListRestoreParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
