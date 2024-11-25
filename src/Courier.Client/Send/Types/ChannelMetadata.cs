using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ChannelMetadata
{
    [JsonPropertyName("utm")]
    public Utm? Utm { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
