using System;
using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Profiles.Lists;

namespace Courier.Services.Profiles.Lists;

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
    }

    public async Task<ListRetrieveResponse> Retrieve(ListRetrieveParams parameters)
    {
        HttpRequest<ListRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var list = await response.Deserialize<ListRetrieveResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            list.Validate();
        }
        return list;
    }

    public async Task<ListDeleteResponse> Delete(ListDeleteParams parameters)
    {
        HttpRequest<ListDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var list = await response.Deserialize<ListDeleteResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            list.Validate();
        }
        return list;
    }

    public async Task<ListSubscribeResponse> Subscribe(ListSubscribeParams parameters)
    {
        HttpRequest<ListSubscribeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<ListSubscribeResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
