using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class NotificationChannel
{
    [JsonPropertyName("id")]
    public string Id { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("content")]
    public NotificationChannelContent? Content { get; init; }

    [JsonPropertyName("locales")]
    public Dictionary<string, NotificationChannelContent>? Locales { get; init; }

    [JsonPropertyName("checksum")]
    public string? Checksum { get; init; }
}
