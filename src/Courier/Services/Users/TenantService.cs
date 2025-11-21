using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Users.Tenants;

namespace Courier.Services.Users;

public sealed class TenantService : global::Courier.Services.Users.ITenantService
{
    public global::Courier.Services.Users.ITenantService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Courier.Services.Users.TenantService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public TenantService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<TenantListResponse> List(
        TenantListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<TenantListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var tenants = await response
            .Deserialize<TenantListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            tenants.Validate();
        }
        return tenants;
    }

    public async Task<TenantListResponse> List(
        string userID,
        TenantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { UserID = userID }, cancellationToken);
    }

    public async Task AddMultiple(
        TenantAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<TenantAddMultipleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task AddMultiple(
        string userID,
        TenantAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.AddMultiple(parameters with { UserID = userID }, cancellationToken);
    }

    public async Task AddSingle(
        TenantAddSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TenantID == null)
        {
            throw new CourierInvalidDataException("'parameters.TenantID' cannot be null");
        }

        HttpRequest<TenantAddSingleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task AddSingle(
        string tenantID,
        TenantAddSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.AddSingle(parameters with { TenantID = tenantID }, cancellationToken);
    }

    public async Task RemoveAll(
        TenantRemoveAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<TenantRemoveAllParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task RemoveAll(
        string userID,
        TenantRemoveAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.RemoveAll(parameters with { UserID = userID }, cancellationToken);
    }

    public async Task RemoveSingle(
        TenantRemoveSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TenantID == null)
        {
            throw new CourierInvalidDataException("'parameters.TenantID' cannot be null");
        }

        HttpRequest<TenantRemoveSingleParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task RemoveSingle(
        string tenantID,
        TenantRemoveSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.RemoveSingle(parameters with { TenantID = tenantID }, cancellationToken);
    }
}
