using System.Text.Json.Serialization;

namespace Courier.Net;

public class BrandColors
{
    [JsonPropertyName("primary")]
    public string? Primary { get; init; }

    [JsonPropertyName("secondary")]
    public string? Secondary { get; init; }

    [JsonPropertyName("tertiary")]
    public string? Tertiary { get; init; }
}
