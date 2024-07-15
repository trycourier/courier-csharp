using System.Net.Http;
using System.Text.Json;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public class TemplatesClient
{
    private RawClient _client;

    public TemplatesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns a list of notification templates
    /// </summary>
    public async Task<ListTemplatesResponse> ListAsync(ListTemplatesRequest request)
    {
        var _query = new Dictionary<string, object>() { };
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = "/notifications",
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<ListTemplatesResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
