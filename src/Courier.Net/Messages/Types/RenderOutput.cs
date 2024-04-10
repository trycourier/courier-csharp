using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class RenderOutput
{
    /// <summary>
    /// The channel used for rendering the message.
    /// </summary>
    [JsonPropertyName("channel")]
    public string Channel { get; init; }

    /// <summary>
    /// The ID of channel used for rendering the message.
    /// </summary>
    [JsonPropertyName("channel_id")]
    public string ChannelId { get; init; }

    /// <summary>
    /// Content details of the rendered message.
    /// </summary>
    [JsonPropertyName("content")]
    public RenderedMessageContent Content { get; init; }
}
