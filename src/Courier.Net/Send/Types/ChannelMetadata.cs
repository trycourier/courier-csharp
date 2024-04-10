using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class ChannelMetadata
{
    [JsonPropertyName("utm")]
    public Utm? Utm { get; init; }
}
