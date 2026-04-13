using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Providers;
using Courier.Services.Providers;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class ProviderService : IProviderService
{
    readonly Lazy<IProviderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProviderServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IProviderService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProviderService(this._client.WithOptions(modifier));
    }

    public ProviderService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ProviderServiceWithRawResponse(client.WithRawResponse));
        _catalog = new(() => new CatalogService(client));
    }

    readonly Lazy<ICatalogService> _catalog;
    public ICatalogService Catalog
    {
        get { return _catalog.Value; }
    }

    /// <inheritdoc/>
    public async Task<Provider> Create(
        ProviderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Provider> Retrieve(
        ProviderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Provider> Retrieve(
        string id,
        ProviderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Provider> Update(
        ProviderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Provider> Update(
        string id,
        ProviderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProviderListResponse> List(
        ProviderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        ProviderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        ProviderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ProviderServiceWithRawResponse : IProviderServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProviderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProviderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProviderServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;

        _catalog = new(() => new CatalogServiceWithRawResponse(client));
    }

    readonly Lazy<ICatalogServiceWithRawResponse> _catalog;
    public ICatalogServiceWithRawResponse Catalog
    {
        get { return _catalog.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Provider>> Create(
        ProviderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ProviderCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var provider = await response.Deserialize<Provider>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    provider.Validate();
                }
                return provider;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Provider>> Retrieve(
        ProviderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProviderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var provider = await response.Deserialize<Provider>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    provider.Validate();
                }
                return provider;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Provider>> Retrieve(
        string id,
        ProviderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Provider>> Update(
        ProviderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProviderUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var provider = await response.Deserialize<Provider>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    provider.Validate();
                }
                return provider;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Provider>> Update(
        string id,
        ProviderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProviderListResponse>> List(
        ProviderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ProviderListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var providers = await response
                    .Deserialize<ProviderListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    providers.Validate();
                }
                return providers;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ProviderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProviderDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        ProviderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }
}
