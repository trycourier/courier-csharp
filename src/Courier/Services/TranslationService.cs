using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Translations;

namespace Courier.Services;

public sealed class TranslationService : ITranslationService
{
    public ITranslationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TranslationService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public TranslationService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<string> Retrieve(
        TranslationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task Update(
        TranslationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TranslationUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
