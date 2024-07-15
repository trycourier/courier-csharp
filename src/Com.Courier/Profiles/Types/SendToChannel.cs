using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record SendToChannel
{
    [JsonPropertyName("channel_id")]
    public required string ChannelId { get; init; }
}
