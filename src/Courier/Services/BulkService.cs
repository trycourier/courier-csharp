using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Bulk;

namespace Courier.Services;

/// <inheritdoc />
public sealed class BulkService : IBulkService
{
    /// <inheritdoc/>
    public IBulkService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BulkService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public BulkService(ICourierClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task AddUsers(
        BulkAddUsersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new CourierInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<BulkAddUsersParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task AddUsers(
        string jobID,
        BulkAddUsersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.AddUsers(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public async Task<BulkListUsersResponse> ListUsers(
        BulkListUsersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new CourierInvalidDataException("'parameters.JobID' cannot be null");
        }

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

    /// <inheritdoc/>
    public async Task<BulkListUsersResponse> ListUsers(
        string jobID,
        BulkListUsersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.ListUsers(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BulkRetrieveJobResponse> RetrieveJob(
        BulkRetrieveJobParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new CourierInvalidDataException("'parameters.JobID' cannot be null");
        }

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

    /// <inheritdoc/>
    public async Task<BulkRetrieveJobResponse> RetrieveJob(
        string jobID,
        BulkRetrieveJobParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.RetrieveJob(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task RunJob(
        BulkRunJobParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new CourierInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<BulkRunJobParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task RunJob(
        string jobID,
        BulkRunJobParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.RunJob(parameters with { JobID = jobID }, cancellationToken);
    }
}
