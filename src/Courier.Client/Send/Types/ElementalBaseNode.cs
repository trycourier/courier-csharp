using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record ElementalBaseNode
{
    [JsonPropertyName("channels")]
    public IEnumerable<string>? Channels { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("loop")]
    public string? Loop { get; init; }
}
