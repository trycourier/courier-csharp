using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record NotificationChannel
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("content")]
    public NotificationChannelContent? Content { get; init; }

    [JsonPropertyName("locales")]
    public Dictionary<string, NotificationChannelContent>? Locales { get; init; }

    [JsonPropertyName("checksum")]
    public string? Checksum { get; init; }
}
