using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record NotificationGetContentResponse
{
    [JsonPropertyName("blocks")]
    public IEnumerable<NotificationBlock>? Blocks { get; set; }

    [JsonPropertyName("channels")]
    public IEnumerable<NotificationChannel>? Channels { get; set; }

    [JsonPropertyName("checksum")]
    public string? Checksum { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
