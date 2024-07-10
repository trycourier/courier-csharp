using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record ElementalDividerNode
{
    /// <summary>
    /// The CSS color to render the line with. For example, `#fff`
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; init; }

    [JsonPropertyName("channels")]
    public IEnumerable<string>? Channels { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("loop")]
    public string? Loop { get; init; }
}
