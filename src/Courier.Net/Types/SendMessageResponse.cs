using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record SendMessageResponse
{
    /// <summary>
    /// A successful call to `POST /send` returns a `202` status code along with a `requestId` in the response body.
    ///
    /// For send requests that have a single recipient, the `requestId` is assigned to the derived message as its message_id. Therefore the `requestId` can be supplied to the Message's API for single recipient messages.
    ///
    /// For send requests that have multiple recipients (accounts, audiences, lists, etc.), Courier assigns a unique id to each derived message as its `message_id`. Therefore the `requestId` cannot be supplied to the Message's API for single-recipient messages.
    /// </summary>
    [JsonPropertyName("requestId")]
    public required string RequestId { get; init; }
}
