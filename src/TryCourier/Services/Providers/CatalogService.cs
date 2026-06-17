using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Providers.Catalog;

namespace TryCourier.Services.Providers;

/// <inheritdoc/>
public sealed class CatalogService : ICatalogService
{
    readonly Lazy<ICatalogServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICatalogServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public ICatalogService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CatalogService(this._client.WithOptions(modifier));
    }

    public CatalogService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CatalogServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CatalogListResponse> List(
        CatalogListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CatalogServiceWithRawResponse : ICatalogServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICatalogServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CatalogServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CatalogServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CatalogListResponse>> List(
        CatalogListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CatalogListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var catalogs = await response
                    .Deserialize<CatalogListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    catalogs.Validate();
                }
                return catalogs;
            }
        );
    }
}
