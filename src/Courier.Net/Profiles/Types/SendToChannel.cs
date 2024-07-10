using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record SendToChannel
{
    [JsonPropertyName("channel_id")]
    public required string ChannelId { get; init; }
}
