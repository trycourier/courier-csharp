using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Brands;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class BrandService : IBrandService
{
    readonly Lazy<IBrandServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBrandServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IBrandService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BrandService(this._client.WithOptions(modifier));
    }

    public BrandService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BrandServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Brand> Create(
        BrandCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Brand> Retrieve(
        BrandRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Brand> Retrieve(
        string brandID,
        BrandRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BrandID = brandID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Brand> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Brand> Update(
        string brandID,
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { BrandID = brandID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BrandListResponse> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Delete(
        BrandDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string brandID,
        BrandDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { BrandID = brandID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BrandServiceWithRawResponse : IBrandServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBrandServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BrandServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BrandServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Brand>> Create(
        BrandCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BrandCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var brand = await response.Deserialize<Brand>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    brand.Validate();
                }
                return brand;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Brand>> Retrieve(
        BrandRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new CourierInvalidDataException("'parameters.BrandID' cannot be null");
        }

        HttpRequest<BrandRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var brand = await response.Deserialize<Brand>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    brand.Validate();
                }
                return brand;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Brand>> Retrieve(
        string brandID,
        BrandRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BrandID = brandID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Brand>> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new CourierInvalidDataException("'parameters.BrandID' cannot be null");
        }

        HttpRequest<BrandUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var brand = await response.Deserialize<Brand>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    brand.Validate();
                }
                return brand;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Brand>> Update(
        string brandID,
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { BrandID = brandID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BrandListResponse>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var brands = await response
                    .Deserialize<BrandListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    brands.Validate();
                }
                return brands;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        BrandDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new CourierInvalidDataException("'parameters.BrandID' cannot be null");
        }

        HttpRequest<BrandDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string brandID,
        BrandDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { BrandID = brandID }, cancellationToken);
    }
}
