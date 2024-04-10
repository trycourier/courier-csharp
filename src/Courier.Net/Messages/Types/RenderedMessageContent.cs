using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class RenderedMessageContent
{
    /// <summary>
    /// The html content of the rendered message.
    /// </summary>
    [JsonPropertyName("html")]
    public string Html { get; init; }

    /// <summary>
    /// The title of the rendered message.
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; init; }

    /// <summary>
    /// The body of the rendered message.
    /// </summary>
    [JsonPropertyName("body")]
    public string Body { get; init; }

    /// <summary>
    /// The subject of the rendered message.
    /// </summary>
    [JsonPropertyName("subject")]
    public string Subject { get; init; }

    /// <summary>
    /// The text of the rendered message.
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; init; }

    /// <summary>
    /// The blocks of the rendered message.
    /// </summary>
    [JsonPropertyName("blocks")]
    public List<RenderedMessageBlock> Blocks { get; init; }
}
