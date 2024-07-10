using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record ElementalActionNode
{
    /// <summary>
    /// The text content of the action shown to the user.
    /// </summary>
    [JsonPropertyName("content")]
    public required string Content { get; init; }

    /// <summary>
    /// The target URL of the action.
    /// </summary>
    [JsonPropertyName("href")]
    public required string Href { get; init; }

    /// <summary>
    /// A unique id used to identify the action when it is executed.
    /// </summary>
    [JsonPropertyName("action_id")]
    public string? ActionId { get; init; }

    /// <summary>
    /// The alignment of the action button. Defaults to "center".
    /// </summary>
    [JsonPropertyName("align")]
    public IAlignment? Align { get; init; }

    /// <summary>
    /// The background color of the action button.
    /// </summary>
    [JsonPropertyName("background_color")]
    public string? BackgroundColor { get; init; }

    /// <summary>
    /// Defaults to `button`.
    /// </summary>
    [JsonPropertyName("style")]
    public IActionButtonStyle? Style { get; init; }

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
