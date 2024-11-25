using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ElementalImageNode
{
    /// <summary>
    /// The source of the image.
    /// </summary>
    [JsonPropertyName("src")]
    public required string Src { get; set; }

    /// <summary>
    /// A URL to link to when the image is clicked.
    /// </summary>
    [JsonPropertyName("href")]
    public string? Href { get; set; }

    /// <summary>
    /// The alignment of the image.
    /// </summary>
    [JsonPropertyName("align")]
    public IAlignment? Align { get; set; }

    /// <summary>
    /// Alternate text for the image.
    /// </summary>
    [JsonPropertyName("altText")]
    public string? AltText { get; set; }

    /// <summary>
    /// CSS width properties to apply to the image. For example, 50px
    /// </summary>
    [JsonPropertyName("width")]
    public string? Width { get; set; }

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
