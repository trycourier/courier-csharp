using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record SubscriptionTopic
{
    /// <summary>
    /// Topic ID
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("status")]
    public required SubscriptionTopicStatus Status { get; set; }

    /// <summary>
    /// Override channel routing with custom preferences. This will override any template prefernces that are set, but a user can still customize their preferences
    /// </summary>
    [JsonPropertyName("has_custom_routing")]
    public bool? HasCustomRouting { get; set; }

    /// <summary>
    /// The default channels to send to this tenant when has_custom_routing is enabled
    /// </summary>
    [JsonPropertyName("custom_routing")]
    public IEnumerable<ChannelClassification>? CustomRouting { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
