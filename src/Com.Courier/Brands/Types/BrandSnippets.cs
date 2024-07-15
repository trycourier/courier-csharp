using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record BrandSnippets
{
    [JsonPropertyName("items")]
    public IEnumerable<BrandSnippet> Items { get; init; } = new List<BrandSnippet>();
}
