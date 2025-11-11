using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Brands;

namespace Courier.Services;

public sealed class BrandService : IBrandService
{
    public IBrandService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BrandService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public BrandService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<Brand> Create(
        BrandCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BrandCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var brand = await response.Deserialize<Brand>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            brand.Validate();
        }
        return brand;
    }

    public async Task<Brand> Retrieve(
        BrandRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BrandRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var brand = await response.Deserialize<Brand>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            brand.Validate();
        }
        return brand;
    }

    public async Task<Brand> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BrandUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var brand = await response.Deserialize<Brand>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            brand.Validate();
        }
        return brand;
    }

    public async Task<BrandListResponse> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BrandListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var brands = await response
            .Deserialize<BrandListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            brands.Validate();
        }
        return brands;
    }

    public async Task Delete(
        BrandDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BrandDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
