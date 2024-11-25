using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ElementalTextNode
{
    /// <summary>
    /// The text content displayed in the notification. Either this
    /// field must be specified, or the elements field
    /// </summary>
    [JsonPropertyName("content")]
    public required string Content { get; set; }

    /// <summary>
    /// Text alignment.
    /// </summary>
    [JsonPropertyName("align")]
    public required TextAlign Align { get; set; }

    /// <summary>
    /// Allows the text to be rendered as a heading level.
    /// </summary>
    [JsonPropertyName("text_style")]
    public TextStyle? TextStyle { get; set; }

    /// <summary>
    /// Specifies the color of text. Can be any valid css color value
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    /// <summary>
    /// Apply bold to the text
    /// </summary>
    [JsonPropertyName("bold")]
    public string? Bold { get; set; }

    /// <summary>
    /// Apply italics to the text
    /// </summary>
    [JsonPropertyName("italic")]
    public string? Italic { get; set; }

    /// <summary>
    /// Apply a strike through the text
    /// </summary>
    [JsonPropertyName("strikethrough")]
    public string? Strikethrough { get; set; }

    /// <summary>
    /// Apply an underline to the text
    /// </summary>
    [JsonPropertyName("underline")]
    public string? Underline { get; set; }

    /// <summary>
    /// Region specific content. See [locales docs](https://www.courier.com/docs/platform/content/elemental/locales/) for more details.
    /// </summary>
    [JsonPropertyName("locales")]
    public Dictionary<string, Locale>? Locales { get; set; }

    [JsonPropertyName("format")]
    public string? Format { get; set; }

    [JsonPropertyName("channels")]
    public IEnumerable<string>? Channels { get; set; }

    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

    [JsonPropertyName("if")]
    public string? If { get; set; }

    [JsonPropertyName("loop")]
    public string? Loop { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
