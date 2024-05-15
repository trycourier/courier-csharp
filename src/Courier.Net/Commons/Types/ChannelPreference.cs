using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class ChannelPreference
{
    [JsonPropertyName("channel")]
    public ChannelClassification Channel { get; init; }
}
