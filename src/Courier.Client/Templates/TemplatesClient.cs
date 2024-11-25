using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public partial class TemplatesClient
{
    private RawClient _client;

    internal TemplatesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns a list of notification templates
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Templates.ListAsync(new ListTemplatesRequest());
    /// </code>
    /// </example>
    public async Task<ListTemplatesResponse> ListAsync(
        ListTemplatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = "/notifications",
                Query = _query,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<ListTemplatesResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
        }

        throw new CourierApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }
}
