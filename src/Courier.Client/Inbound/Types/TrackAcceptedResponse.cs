using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record TrackAcceptedResponse
{
    /// <summary>
    /// A successful call returns a `202` status code along with a `requestId` in the response body.
    /// </summary>
    [JsonPropertyName("messageId")]
    public required string MessageId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
