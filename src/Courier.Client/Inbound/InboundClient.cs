using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Courier.Client.Core;

namespace Courier.Client;

public partial class InboundClient
{
    private RawClient _client;

    internal InboundClient(RawClient client)
    {
        _client = client;
    }

    /// <example><code>
    /// await client.Inbound.TrackAsync(
    ///     new InboundTrackEvent
    ///     {
    ///         Event = "New Order Placed",
    ///         MessageId = "4c62c457-b329-4bea-9bfc-17bba86c393f",
    ///         UserId = "1234",
    ///         Type = "track",
    ///         Properties = new Dictionary&lt;string, object&gt;()
    ///         {
    ///             { "order_id", 123 },
    ///             { "total_orders", 5 },
    ///             { "last_order_id", 122 },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<TrackAcceptedResponse> TrackAsync(
        InboundTrackEvent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "/inbound/courier",
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<TrackAcceptedResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<BadRequest>(responseBody));
                    case 409:
                        throw new ConflictError(JsonUtils.Deserialize<Conflict>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new CourierApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
