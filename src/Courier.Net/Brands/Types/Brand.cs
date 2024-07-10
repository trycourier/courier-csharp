using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record Brand
{
    /// <summary>
    /// The date/time of when the brand was created. Represented in milliseconds since Unix epoch.
    /// </summary>
    [JsonPropertyName("created")]
    public required int Created { get; init; }

    /// <summary>
    /// Brand Identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Brand name
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// The date/time of when the brand was published. Represented in milliseconds since Unix epoch.
    /// </summary>
    [JsonPropertyName("published")]
    public required int Published { get; init; }

    [JsonPropertyName("settings")]
    public required BrandSettings Settings { get; init; }

    /// <summary>
    /// The date/time of when the brand was updated. Represented in milliseconds since Unix epoch.
    /// </summary>
    [JsonPropertyName("updated")]
    public required int Updated { get; init; }

    [JsonPropertyName("snippets")]
    public BrandSnippets? Snippets { get; init; }

    /// <summary>
    /// The version identifier for the brand
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; init; }
}
