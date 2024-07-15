using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record BrandUpdateParameters
{
    /// <summary>
    /// The name of the brand.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("settings")]
    public BrandSettings? Settings { get; init; }

    [JsonPropertyName("snippets")]
    public BrandSnippets? Snippets { get; init; }
}
