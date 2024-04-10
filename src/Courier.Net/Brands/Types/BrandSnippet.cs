using System.Text.Json.Serialization;

namespace Courier.Net;

public class BrandSnippet
{
    [JsonPropertyName("format")]
    public string Format { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("value")]
    public string Value { get; init; }
}
