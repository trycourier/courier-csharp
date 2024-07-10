using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record ChannelPreference
{
    [JsonPropertyName("channel")]
    public required ChannelClassification Channel { get; init; }
}
