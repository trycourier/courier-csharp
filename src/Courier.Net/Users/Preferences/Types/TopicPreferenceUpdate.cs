using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net.Users;

public class TopicPreferenceUpdate
{
    [JsonPropertyName("status")]
    public PreferenceStatus Status { get; init; }

    /// <summary>
    /// The Channels a user has chosen to receive notifications through for this topic
    /// </summary>
    [JsonPropertyName("custom_routing")]
    public List<ChannelClassification>? CustomRouting { get; init; }

    [JsonPropertyName("has_custom_routing")]
    public bool? HasCustomRouting { get; init; }
}
