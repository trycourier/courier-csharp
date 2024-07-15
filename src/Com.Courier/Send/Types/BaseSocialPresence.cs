using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record BaseSocialPresence
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }
}
