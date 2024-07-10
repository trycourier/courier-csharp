using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record InboundTrackEvent
{
    /// <summary>
    /// A descriptive name of the event. This name will appear as a trigger in the Courier Automation Trigger node.
    /// </summary>
    [JsonPropertyName("event")]
    public required string Event { get; init; }

    /// <summary>
    /// A required unique identifier that will be used to de-duplicate requests. If not unique, will respond with 409 Conflict status
    /// </summary>
    [JsonPropertyName("messageId")]
    public required string MessageId { get; init; }

    [JsonPropertyName("properties")]
    public Dictionary<string, object> Properties { get; init; } = new Dictionary<string, object>();

    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>
    /// The user id assocatiated with the track
    /// </summary>
    [JsonPropertyName("userId")]
    public string? UserId { get; init; }
}
