using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record Locale
{
    [JsonPropertyName("content")]
    public required string Content { get; init; }
}
