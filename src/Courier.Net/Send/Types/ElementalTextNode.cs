using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record ElementalTextNode
{
    /// <summary>
    /// The text content displayed in the notification. Either this
    /// field must be specified, or the elements field
    /// </summary>
    [JsonPropertyName("content")]
    public required string Content { get; init; }

    /// <summary>
    /// Text alignment.
    /// </summary>
    [JsonPropertyName("align")]
    public required TextAlign Align { get; init; }

    /// <summary>
    /// Allows the text to be rendered as a heading level.
    /// </summary>
    [JsonPropertyName("text_style")]
    public TextStyle? TextStyle { get; init; }

    /// <summary>
    /// Specifies the color of text. Can be any valid css color value
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; init; }

    /// <summary>
    /// Apply bold to the text
    /// </summary>
    [JsonPropertyName("bold")]
    public string? Bold { get; init; }

    /// <summary>
    /// Apply italics to the text
    /// </summary>
    [JsonPropertyName("italic")]
    public string? Italic { get; init; }

    /// <summary>
    /// Apply a strike through the text
    /// </summary>
    [JsonPropertyName("strikethrough")]
    public string? Strikethrough { get; init; }

    /// <summary>
    /// Apply an underline to the text
    /// </summary>
    [JsonPropertyName("underline")]
    public string? Underline { get; init; }

    /// <summary>
    /// Region specific content. See [locales docs](https://www.courier.com/docs/platform/content/elemental/locales/) for more details.
    /// </summary>
    [JsonPropertyName("locales")]
    public Dictionary<string, Locale>? Locales { get; init; }

    [JsonPropertyName("format")]
    public string? Format { get; init; }

    [JsonPropertyName("channels")]
    public IEnumerable<string>? Channels { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("loop")]
    public string? Loop { get; init; }
}
