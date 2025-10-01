using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Users.Tenants;

namespace Courier.Services.Users.Tenants;

public sealed class TenantService : ITenantService
{
    readonly ICourierClient _client;

    public TenantService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<TenantListResponse> List(TenantListParams parameters)
    {
        HttpRequest<TenantListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<TenantListResponse>().ConfigureAwait(false);
    }

    public async Task AddMultiple(TenantAddMultipleParams parameters)
    {
        HttpRequest<TenantAddMultipleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task AddSingle(TenantAddSingleParams parameters)
    {
        HttpRequest<TenantAddSingleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task RemoveAll(TenantRemoveAllParams parameters)
    {
        HttpRequest<TenantRemoveAllParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task RemoveSingle(TenantRemoveSingleParams parameters)
    {
        HttpRequest<TenantRemoveSingleParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }
}
