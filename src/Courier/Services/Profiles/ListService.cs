using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Profiles.Lists;

namespace Courier.Services.Profiles;

public sealed class ListService : global::Courier.Services.Profiles.IListService
{
    public global::Courier.Services.Profiles.IListService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Courier.Services.Profiles.ListService(
            this._client.WithOptions(modifier)
        );
    }

    readonly ICourierClient _client;

    public ListService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<ListRetrieveResponse> Retrieve(
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
        var list = await response
            .Deserialize<ListRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            list.Validate();
        }
        return list;
    }

    public async Task<ListDeleteResponse> Delete(
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
        var list = await response
            .Deserialize<ListDeleteResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            list.Validate();
        }
        return list;
    }

    public async Task<ListSubscribeResponse> Subscribe(
        ListSubscribeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ListSubscribeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<ListSubscribeResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
