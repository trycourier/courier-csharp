using System.Text.Json.Serialization;

namespace Courier.Net;

public class RenderedMessageBlock
{
    /// <summary>
    /// The block type of the rendered message block.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; }

    /// <summary>
    /// The block text of the rendered message block.
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; init; }
}
