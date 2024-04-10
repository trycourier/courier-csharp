using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net.Users;

public class TopicPreference
{
    /// <summary>
    /// The Channels a user has chosen to receive notifications through for this topic
    /// </summary>
    [JsonPropertyName("custom_routing")]
    public List<ChannelClassification>? CustomRouting { get; init; }

    [JsonPropertyName("default_status")]
    public PreferenceStatus DefaultStatus { get; init; }

    [JsonPropertyName("has_custom_routing")]
    public bool? HasCustomRouting { get; init; }

    [JsonPropertyName("status")]
    public PreferenceStatus Status { get; init; }

    [JsonPropertyName("topic_id")]
    public string TopicId { get; init; }

    [JsonPropertyName("topic_name")]
    public string TopicName { get; init; }
}
