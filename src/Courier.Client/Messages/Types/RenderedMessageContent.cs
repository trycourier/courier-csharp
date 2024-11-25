using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record RenderedMessageContent
{
    /// <summary>
    /// The html content of the rendered message.
    /// </summary>
    [JsonPropertyName("html")]
    public required string Html { get; set; }

    /// <summary>
    /// The title of the rendered message.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// The body of the rendered message.
    /// </summary>
    [JsonPropertyName("body")]
    public required string Body { get; set; }

    /// <summary>
    /// The subject of the rendered message.
    /// </summary>
    [JsonPropertyName("subject")]
    public required string Subject { get; set; }

    /// <summary>
    /// The text of the rendered message.
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    /// <summary>
    /// The blocks of the rendered message.
    /// </summary>
    [JsonPropertyName("blocks")]
    public IEnumerable<RenderedMessageBlock> Blocks { get; set; } =
        new List<RenderedMessageBlock>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
