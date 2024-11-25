using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record RenderedMessageBlock
{
    /// <summary>
    /// The block type of the rendered message block.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// The block text of the rendered message block.
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
