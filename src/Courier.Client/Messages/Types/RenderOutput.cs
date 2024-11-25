using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record RenderOutput
{
    /// <summary>
    /// The channel used for rendering the message.
    /// </summary>
    [JsonPropertyName("channel")]
    public required string Channel { get; set; }

    /// <summary>
    /// The ID of channel used for rendering the message.
    /// </summary>
    [JsonPropertyName("channel_id")]
    public required string ChannelId { get; set; }

    /// <summary>
    /// Content details of the rendered message.
    /// </summary>
    [JsonPropertyName("content")]
    public required RenderedMessageContent Content { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
