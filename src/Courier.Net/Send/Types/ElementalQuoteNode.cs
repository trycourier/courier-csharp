using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class ElementalQuoteNode
{
    /// <summary>
    /// The text value of the quote.
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; init; }

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
    public TextStyle TextStyle { get; init; }

    /// <summary>
    /// Region specific content. See [locales docs](https://www.courier.com/docs/platform/content/elemental/locales/) for more details.
    /// </summary>
    [JsonPropertyName("locales")]
    public Dictionary<string, Locale>? Locales { get; init; }

    [JsonPropertyName("channels")]
    public List<string>? Channels { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("loop")]
    public string? Loop { get; init; }
}
