using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class BrandSnippets
{
    [JsonPropertyName("items")]
    public List<BrandSnippet> Items { get; init; }
}
