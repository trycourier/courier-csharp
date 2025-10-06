using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Brands;

namespace Courier.Services.Brands;

public sealed class BrandService : IBrandService
{
    readonly ICourierClient _client;

    public BrandService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<Brand> Create(BrandCreateParams parameters)
    {
        HttpRequest<BrandCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Brand>().ConfigureAwait(false);
    }

    public async Task<Brand> Retrieve(BrandRetrieveParams parameters)
    {
        HttpRequest<BrandRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Brand>().ConfigureAwait(false);
    }

    public async Task<Brand> Update(BrandUpdateParams parameters)
    {
        HttpRequest<BrandUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Brand>().ConfigureAwait(false);
    }

    public async Task<BrandListResponse> List(BrandListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<BrandListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BrandListResponse>().ConfigureAwait(false);
    }

    public async Task Delete(BrandDeleteParams parameters)
    {
        HttpRequest<BrandDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }
}
