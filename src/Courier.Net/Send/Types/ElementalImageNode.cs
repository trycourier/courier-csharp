using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record ElementalImageNode
{
    /// <summary>
    /// The source of the image.
    /// </summary>
    [JsonPropertyName("src")]
    public required string Src { get; init; }

    /// <summary>
    /// A URL to link to when the image is clicked.
    /// </summary>
    [JsonPropertyName("href")]
    public string? Href { get; init; }

    /// <summary>
    /// The alignment of the image.
    /// </summary>
    [JsonPropertyName("align")]
    public IAlignment? Align { get; init; }

    /// <summary>
    /// Alternate text for the image.
    /// </summary>
    [JsonPropertyName("altText")]
    public string? AltText { get; init; }

    /// <summary>
    /// CSS width properties to apply to the image. For example, 50px
    /// </summary>
    [JsonPropertyName("width")]
    public string? Width { get; init; }

    [JsonPropertyName("channels")]
    public IEnumerable<string>? Channels { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("loop")]
    public string? Loop { get; init; }
}
