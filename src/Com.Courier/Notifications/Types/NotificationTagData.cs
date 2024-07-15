using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record NotificationTagData
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }
}
