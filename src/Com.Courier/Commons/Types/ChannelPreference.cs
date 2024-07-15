using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record ChannelPreference
{
    [JsonPropertyName("channel")]
    public required ChannelClassification Channel { get; init; }
}
