using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record NotificationGetContentResponse
{
    [JsonPropertyName("blocks")]
    public IEnumerable<NotificationBlock>? Blocks { get; init; }

    [JsonPropertyName("channels")]
    public IEnumerable<NotificationChannel>? Channels { get; init; }

    [JsonPropertyName("checksum")]
    public string? Checksum { get; init; }
}
