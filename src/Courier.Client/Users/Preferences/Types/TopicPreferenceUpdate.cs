using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

public record TopicPreferenceUpdate
{
    [JsonPropertyName("status")]
    public required PreferenceStatus Status { get; set; }

    /// <summary>
    /// The Channels a user has chosen to receive notifications through for this topic
    /// </summary>
    [JsonPropertyName("custom_routing")]
    public IEnumerable<ChannelClassification>? CustomRouting { get; set; }

    [JsonPropertyName("has_custom_routing")]
    public bool? HasCustomRouting { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
