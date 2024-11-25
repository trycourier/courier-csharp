using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record SendToChannel
{
    [JsonPropertyName("channel_id")]
    public required string ChannelId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
