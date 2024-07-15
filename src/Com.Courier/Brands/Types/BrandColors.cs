using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record BrandColors
{
    [JsonPropertyName("primary")]
    public string? Primary { get; init; }

    [JsonPropertyName("secondary")]
    public string? Secondary { get; init; }

    [JsonPropertyName("tertiary")]
    public string? Tertiary { get; init; }
}
