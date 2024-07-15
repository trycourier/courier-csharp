using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record RenderedMessageBlock
{
    /// <summary>
    /// The block type of the rendered message block.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>
    /// The block text of the rendered message block.
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; init; }
}
