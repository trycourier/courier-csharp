using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client.Users;

public record TopicPreferenceUpdate
{
    [JsonPropertyName("status")]
    public required PreferenceStatus Status { get; init; }

    /// <summary>
    /// The Channels a user has chosen to receive notifications through for this topic
    /// </summary>
    [JsonPropertyName("custom_routing")]
    public IEnumerable<ChannelClassification>? CustomRouting { get; init; }

    [JsonPropertyName("has_custom_routing")]
    public bool? HasCustomRouting { get; init; }
}
