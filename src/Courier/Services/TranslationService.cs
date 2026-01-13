using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Translations;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class TranslationService : ITranslationService
{
    readonly Lazy<ITranslationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITranslationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public ITranslationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TranslationService(this._client.WithOptions(modifier));
    }

    public TranslationService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TranslationServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<string> Retrieve(
        TranslationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<string> Retrieve(
        string locale,
        TranslationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { Locale = locale }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Update(
        TranslationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string locale,
        TranslationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with { Locale = locale }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TranslationServiceWithRawResponse : ITranslationServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITranslationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TranslationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TranslationServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<string>> Retrieve(
        TranslationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Locale == null)
        {
            throw new CourierInvalidDataException("'parameters.Locale' cannot be null");
        }

        HttpRequest<TranslationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<string>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<string>> Retrieve(
        string locale,
        TranslationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { Locale = locale }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        TranslationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Locale == null)
        {
            throw new CourierInvalidDataException("'parameters.Locale' cannot be null");
        }

        HttpRequest<TranslationUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string locale,
        TranslationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { Locale = locale }, cancellationToken);
    }
}
