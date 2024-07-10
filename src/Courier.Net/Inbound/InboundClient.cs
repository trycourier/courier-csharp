using System.Net.Http;
using System.Text.Json;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

public class InboundClient
{
    private RawClient _client;

    public InboundClient(RawClient client)
    {
        _client = client;
    }

    public async Task<TrackAcceptedResponse> TrackAsync(InboundTrackEvent request)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = "/inbound/courier",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<TrackAcceptedResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
