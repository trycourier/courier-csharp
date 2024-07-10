using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record ElementalGroupNode
{
    /// <summary>
    /// Sub elements to render.
    /// </summary>
    [JsonPropertyName("elements")]
    public IEnumerable<object> Elements { get; init; } = new List<object>();

    [JsonPropertyName("channels")]
    public IEnumerable<string>? Channels { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("loop")]
    public string? Loop { get; init; }
}
