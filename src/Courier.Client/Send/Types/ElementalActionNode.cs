using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ElementalActionNode
{
    /// <summary>
    /// The text content of the action shown to the user.
    /// </summary>
    [JsonPropertyName("content")]
    public required string Content { get; set; }

    /// <summary>
    /// The target URL of the action.
    /// </summary>
    [JsonPropertyName("href")]
    public required string Href { get; set; }

    /// <summary>
    /// A unique id used to identify the action when it is executed.
    /// </summary>
    [JsonPropertyName("action_id")]
    public string? ActionId { get; set; }

    /// <summary>
    /// The alignment of the action button. Defaults to "center".
    /// </summary>
    [JsonPropertyName("align")]
    public IAlignment? Align { get; set; }

    /// <summary>
    /// The background color of the action button.
    /// </summary>
    [JsonPropertyName("background_color")]
    public string? BackgroundColor { get; set; }

    /// <summary>
    /// Defaults to `button`.
    /// </summary>
    [JsonPropertyName("style")]
    public IActionButtonStyle? Style { get; set; }

    /// <summary>
    /// Region specific content. See [locales docs](https://www.courier.com/docs/platform/content/elemental/locales/) for more details.
    /// </summary>
    [JsonPropertyName("locales")]
    public Dictionary<string, Locale>? Locales { get; set; }

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
