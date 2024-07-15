using System.Net.Http;
using System.Text.Json;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public class TranslationsClient
{
    private RawClient _client;

    public TranslationsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Get translations by locale
    /// </summary>
    public async Task<string> GetAsync(string domain, string locale)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = $"/translations/{domain}/{locale}"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<string>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Update a translation
    /// </summary>
    public async Task UpdateAsync(string domain, string locale, string request)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Put,
                Path = $"/translations/{domain}/{locale}",
                Body = request
            }
        );
    }
}
