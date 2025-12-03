using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Translations;

namespace Courier.Services;

/// <inheritdoc />
public sealed class TranslationService : ITranslationService
{
    /// <inheritdoc/>
    public ITranslationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TranslationService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public TranslationService(ICourierClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<string> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize<string>(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<string> Retrieve(
        string locale,
        TranslationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Retrieve(parameters with { Locale = locale }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Update(
        string locale,
        TranslationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with { Locale = locale }, cancellationToken);
    }
}
