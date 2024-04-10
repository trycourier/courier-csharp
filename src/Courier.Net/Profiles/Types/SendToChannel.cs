using System.Text.Json.Serialization;

namespace Courier.Net;

public class SendToChannel
{
    [JsonPropertyName("channel_id")]
    public string ChannelId { get; init; }
}
