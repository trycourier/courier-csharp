using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record BrandSnippets
{
    [JsonPropertyName("items")]
    public IEnumerable<BrandSnippet> Items { get; init; } = new List<BrandSnippet>();
}
