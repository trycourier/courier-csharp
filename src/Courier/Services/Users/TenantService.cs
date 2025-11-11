using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
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

    public async Task AddMultiple(
        TenantAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TenantAddMultipleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task AddSingle(
        TenantAddSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TenantAddSingleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task RemoveAll(
        TenantRemoveAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TenantRemoveAllParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task RemoveSingle(
        TenantRemoveSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TenantRemoveSingleParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
