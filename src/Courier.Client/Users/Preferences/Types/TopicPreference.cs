using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

public record TopicPreference
{
    /// <summary>
    /// The Channels a user has chosen to receive notifications through for this topic
    /// </summary>
    [JsonPropertyName("custom_routing")]
    public IEnumerable<ChannelClassification>? CustomRouting { get; set; }

    [JsonPropertyName("default_status")]
    public required PreferenceStatus DefaultStatus { get; set; }

    [JsonPropertyName("has_custom_routing")]
    public bool? HasCustomRouting { get; set; }

    [JsonPropertyName("status")]
    public required PreferenceStatus Status { get; set; }

    [JsonPropertyName("topic_id")]
    public required string TopicId { get; set; }

    [JsonPropertyName("topic_name")]
    public required string TopicName { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
