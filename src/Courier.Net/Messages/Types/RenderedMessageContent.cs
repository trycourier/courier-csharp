using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record RenderedMessageContent
{
    /// <summary>
    /// The html content of the rendered message.
    /// </summary>
    [JsonPropertyName("html")]
    public required string Html { get; init; }

    /// <summary>
    /// The title of the rendered message.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; init; }

    /// <summary>
    /// The body of the rendered message.
    /// </summary>
    [JsonPropertyName("body")]
    public required string Body { get; init; }

    /// <summary>
    /// The subject of the rendered message.
    /// </summary>
    [JsonPropertyName("subject")]
    public required string Subject { get; init; }

    /// <summary>
    /// The text of the rendered message.
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; init; }

    /// <summary>
    /// The blocks of the rendered message.
    /// </summary>
    [JsonPropertyName("blocks")]
    public IEnumerable<RenderedMessageBlock> Blocks { get; init; } =
        new List<RenderedMessageBlock>();
}
