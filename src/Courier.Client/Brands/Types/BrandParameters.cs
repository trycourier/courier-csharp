using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BrandParameters
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The name of the brand.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("settings")]
    public required BrandSettings Settings { get; set; }

    [JsonPropertyName("snippets")]
    public BrandSnippets? Snippets { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
