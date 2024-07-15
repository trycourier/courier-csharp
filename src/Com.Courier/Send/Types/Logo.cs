using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record Logo
{
    [JsonPropertyName("href")]
    public string? Href { get; init; }

    [JsonPropertyName("image")]
    public string? Image { get; init; }
}
