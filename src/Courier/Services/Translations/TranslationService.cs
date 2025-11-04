using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Translations;

namespace Courier.Services.Translations;

public sealed class TranslationService : ITranslationService
{
    readonly ICourierClient _client;

    public TranslationService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<string> Retrieve(TranslationRetrieveParams parameters)
    {
        HttpRequest<TranslationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<string>().ConfigureAwait(false);
    }

    public async Task Update(TranslationUpdateParams parameters)
    {
        HttpRequest<TranslationUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }
}
