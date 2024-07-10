using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net.Users;

public record TopicPreference
{
    /// <summary>
    /// The Channels a user has chosen to receive notifications through for this topic
    /// </summary>
    [JsonPropertyName("custom_routing")]
    public IEnumerable<ChannelClassification>? CustomRouting { get; init; }

    [JsonPropertyName("default_status")]
    public required PreferenceStatus DefaultStatus { get; init; }

    [JsonPropertyName("has_custom_routing")]
    public bool? HasCustomRouting { get; init; }

    [JsonPropertyName("status")]
    public required PreferenceStatus Status { get; init; }

    [JsonPropertyName("topic_id")]
    public required string TopicId { get; init; }

    [JsonPropertyName("topic_name")]
    public required string TopicName { get; init; }
}
