using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record NotificationChannel
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("content")]
    public NotificationChannelContent? Content { get; set; }

    [JsonPropertyName("locales")]
    public Dictionary<string, NotificationChannelContent>? Locales { get; set; }

    [JsonPropertyName("checksum")]
    public string? Checksum { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
