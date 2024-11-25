using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BrandColors
{
    [JsonPropertyName("primary")]
    public string? Primary { get; set; }

    [JsonPropertyName("secondary")]
    public string? Secondary { get; set; }

    [JsonPropertyName("tertiary")]
    public string? Tertiary { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
