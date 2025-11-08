using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Tenants = Courier.Models.Users.Tenants;

namespace Courier.Services.Users.Tenants;

public sealed class TenantService : ITenantService
{
    public ITenantService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TenantService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public TenantService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<Tenants::TenantListResponse> List(
        Tenants::TenantListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Tenants::TenantListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var tenants = await response
            .Deserialize<Tenants::TenantListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            tenants.Validate();
        }
        return tenants;
    }

    public async Task AddMultiple(
        Tenants::TenantAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Tenants::TenantAddMultipleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task AddSingle(
        Tenants::TenantAddSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Tenants::TenantAddSingleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task RemoveAll(
        Tenants::TenantRemoveAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Tenants::TenantRemoveAllParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task RemoveSingle(
        Tenants::TenantRemoveSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Tenants::TenantRemoveSingleParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
