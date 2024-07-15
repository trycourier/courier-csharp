using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record NotificationGetContentResponse
{
    [JsonPropertyName("blocks")]
    public IEnumerable<NotificationBlock>? Blocks { get; init; }

    [JsonPropertyName("channels")]
    public IEnumerable<NotificationChannel>? Channels { get; init; }

    [JsonPropertyName("checksum")]
    public string? Checksum { get; init; }
}
