using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record TrackAcceptedResponse
{
    /// <summary>
    /// A successful call returns a `202` status code along with a `requestId` in the response body.
    /// </summary>
    [JsonPropertyName("messageId")]
    public required string MessageId { get; init; }
}
