using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class BrandParameters
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// The name of the brand.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("settings")]
    public BrandSettings Settings { get; init; }

    [JsonPropertyName("snippets")]
    public BrandSnippets? Snippets { get; init; }
}
