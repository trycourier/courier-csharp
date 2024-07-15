using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record ChannelMetadata
{
    [JsonPropertyName("utm")]
    public Utm? Utm { get; init; }
}
