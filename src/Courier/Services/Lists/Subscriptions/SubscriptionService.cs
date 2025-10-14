using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Lists.Subscriptions;

namespace Courier.Services.Lists.Subscriptions;

public sealed class SubscriptionService : ISubscriptionService
{
    readonly ICourierClient _client;

    public SubscriptionService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<SubscriptionListResponse> List(SubscriptionListParams parameters)
    {
        HttpRequest<SubscriptionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<SubscriptionListResponse>().ConfigureAwait(false);
    }

    public async Task Add(SubscriptionAddParams parameters)
    {
        HttpRequest<SubscriptionAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task Subscribe(SubscriptionSubscribeParams parameters)
    {
        HttpRequest<SubscriptionSubscribeParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task SubscribeUser(SubscriptionSubscribeUserParams parameters)
    {
        HttpRequest<SubscriptionSubscribeUserParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task UnsubscribeUser(SubscriptionUnsubscribeUserParams parameters)
    {
        HttpRequest<SubscriptionUnsubscribeUserParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }
}
