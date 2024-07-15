using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record BrandParameters
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// The name of the brand.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("settings")]
    public required BrandSettings Settings { get; init; }

    [JsonPropertyName("snippets")]
    public BrandSnippets? Snippets { get; init; }
}
