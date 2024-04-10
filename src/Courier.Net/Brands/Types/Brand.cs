using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class Brand
{
    /// <summary>
    /// The date/time of when the brand was created. Represented in milliseconds since Unix epoch.
    /// </summary>
    [JsonPropertyName("created")]
    public int Created { get; init; }

    /// <summary>
    /// Brand Identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Brand name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }

    /// <summary>
    /// The date/time of when the brand was published. Represented in milliseconds since Unix epoch.
    /// </summary>
    [JsonPropertyName("published")]
    public int Published { get; init; }

    [JsonPropertyName("settings")]
    public BrandSettings Settings { get; init; }

    /// <summary>
    /// The date/time of when the brand was updated. Represented in milliseconds since Unix epoch.
    /// </summary>
    [JsonPropertyName("updated")]
    public int Updated { get; init; }

    [JsonPropertyName("snippets")]
    public BrandSnippets? Snippets { get; init; }

    /// <summary>
    /// The version identifier for the brand
    /// </summary>
    [JsonPropertyName("version")]
    public string Version { get; init; }
}
