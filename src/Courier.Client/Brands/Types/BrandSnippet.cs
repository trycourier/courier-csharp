using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record BrandSnippet
{
    [JsonPropertyName("format")]
    public required string Format { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("value")]
    public required string Value { get; init; }
}
