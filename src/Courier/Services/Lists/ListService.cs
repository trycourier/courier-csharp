using System;
using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Lists;
using Courier.Services.Lists.Subscriptions;

namespace Courier.Services.Lists;

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

    public async Task<SubscriptionList> Retrieve(ListRetrieveParams parameters)
    {
        HttpRequest<ListRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var subscriptionList = await response.Deserialize<SubscriptionList>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            subscriptionList.Validate();
        }
        return subscriptionList;
    }

    public async Task Update(ListUpdateParams parameters)
    {
        HttpRequest<ListUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task<ListListResponse> List(ListListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<ListListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var lists = await response.Deserialize<ListListResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            lists.Validate();
        }
        return lists;
    }

    public async Task Delete(ListDeleteParams parameters)
    {
        HttpRequest<ListDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task Restore(ListRestoreParams parameters)
    {
        HttpRequest<ListRestoreParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }
}
