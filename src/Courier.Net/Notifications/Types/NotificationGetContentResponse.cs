using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class NotificationGetContentResponse
{
    [JsonPropertyName("blocks")]
    public List<NotificationBlock>? Blocks { get; init; }

    [JsonPropertyName("channels")]
    public List<NotificationChannel>? Channels { get; init; }

    [JsonPropertyName("checksum")]
    public string? Checksum { get; init; }
}
