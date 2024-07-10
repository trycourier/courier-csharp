using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record BrandSnippets
{
    [JsonPropertyName("items")]
    public IEnumerable<BrandSnippet> Items { get; init; } = new List<BrandSnippet>();
}
