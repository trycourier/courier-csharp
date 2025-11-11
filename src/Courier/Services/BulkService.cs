using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Bulk;

namespace Courier.Services;

public sealed class BulkService : IBulkService
{
    public IBulkService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BulkService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public BulkService(ICourierClient client)
    {
        _client = client;
    }

    public async Task AddUsers(
        BulkAddUsersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BulkAddUsersParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<BulkCreateJobResponse> CreateJob(
        BulkCreateJobParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BulkCreateJobParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<BulkCreateJobResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<BulkListUsersResponse> ListUsers(
        BulkListUsersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BulkListUsersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<BulkListUsersResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<BulkRetrieveJobResponse> RetrieveJob(
        BulkRetrieveJobParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BulkRetrieveJobParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<BulkRetrieveJobResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task RunJob(
        BulkRunJobParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BulkRunJobParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
