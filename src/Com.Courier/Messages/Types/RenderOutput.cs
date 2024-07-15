using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record RenderOutput
{
    /// <summary>
    /// The channel used for rendering the message.
    /// </summary>
    [JsonPropertyName("channel")]
    public required string Channel { get; init; }

    /// <summary>
    /// The ID of channel used for rendering the message.
    /// </summary>
    [JsonPropertyName("channel_id")]
    public required string ChannelId { get; init; }

    /// <summary>
    /// Content details of the rendered message.
    /// </summary>
    [JsonPropertyName("content")]
    public required RenderedMessageContent Content { get; init; }
}
