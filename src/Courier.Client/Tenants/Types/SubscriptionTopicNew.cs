using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record SubscriptionTopicNew
{
    [JsonPropertyName("status")]
    public required SubscriptionTopicStatus Status { get; init; }

    /// <summary>
    /// Override channel routing with custom preferences. This will override any template prefernces that are set, but a user can still customize their preferences
    /// </summary>
    [JsonPropertyName("has_custom_routing")]
    public bool? HasCustomRouting { get; init; }

    /// <summary>
    /// The default channels to send to this tenant when has_custom_routing is enabled
    /// </summary>
    [JsonPropertyName("custom_routing")]
    public IEnumerable<ChannelClassification>? CustomRouting { get; init; }
}
