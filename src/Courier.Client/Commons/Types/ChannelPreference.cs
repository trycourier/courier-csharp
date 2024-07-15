using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record ChannelPreference
{
    [JsonPropertyName("channel")]
    public required ChannelClassification Channel { get; init; }
}
