using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BrandSnippets
{
    [JsonPropertyName("items")]
    public IEnumerable<BrandSnippet> Items { get; set; } = new List<BrandSnippet>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
