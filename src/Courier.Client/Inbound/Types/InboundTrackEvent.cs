using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record InboundTrackEvent
{
    /// <summary>
    /// A descriptive name of the event. This name will appear as a trigger in the Courier Automation Trigger node.
    /// </summary>
    [JsonPropertyName("event")]
    public required string Event { get; set; }

    /// <summary>
    /// A required unique identifier that will be used to de-duplicate requests. If not unique, will respond with 409 Conflict status
    /// </summary>
    [JsonPropertyName("messageId")]
    public required string MessageId { get; set; }

    [JsonPropertyName("properties")]
    public Dictionary<string, object?> Properties { get; set; } = new Dictionary<string, object?>();

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// The user id assocatiated with the track
    /// </summary>
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
