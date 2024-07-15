using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record ElementalQuoteNode
{
    /// <summary>
    /// The text value of the quote.
    /// </summary>
    [JsonPropertyName("content")]
    public required string Content { get; init; }

    /// <summary>
    /// Alignment of the quote.
    /// </summary>
    [JsonPropertyName("align")]
    public IAlignment? Align { get; init; }

    /// <summary>
    /// CSS border color property. For example, `#fff`
    /// </summary>
    [JsonPropertyName("borderColor")]
    public string? BorderColor { get; init; }

    [JsonPropertyName("text_style")]
    public required TextStyle TextStyle { get; init; }

    /// <summary>
    /// Region specific content. See [locales docs](https://www.courier.com/docs/platform/content/elemental/locales/) for more details.
    /// </summary>
    [JsonPropertyName("locales")]
    public Dictionary<string, Locale>? Locales { get; init; }

    [JsonPropertyName("channels")]
    public IEnumerable<string>? Channels { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("loop")]
    public string? Loop { get; init; }
}
