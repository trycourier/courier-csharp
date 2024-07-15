using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record AutomationAddToDigestStep
{
    [JsonPropertyName("action")]
    public required string Action { get; init; }

    /// <summary>
    /// The subscription topic that has digests enabled
    /// </summary>
    [JsonPropertyName("subscription_topic_id")]
    public required string SubscriptionTopicId { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
