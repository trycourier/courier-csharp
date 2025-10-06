using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Profiles.Lists;

namespace Courier.Services.Profiles.Lists;

public sealed class ListService : IListService
{
    readonly ICourierClient _client;

    public ListService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<ListRetrieveResponse> Retrieve(ListRetrieveParams parameters)
    {
        HttpRequest<ListRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<ListRetrieveResponse>().ConfigureAwait(false);
    }

    public async Task<ListDeleteResponse> Delete(ListDeleteParams parameters)
    {
        HttpRequest<ListDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<ListDeleteResponse>().ConfigureAwait(false);
    }

    public async Task<ListSubscribeResponse> Subscribe(ListSubscribeParams parameters)
    {
        HttpRequest<ListSubscribeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<ListSubscribeResponse>().ConfigureAwait(false);
    }
}
