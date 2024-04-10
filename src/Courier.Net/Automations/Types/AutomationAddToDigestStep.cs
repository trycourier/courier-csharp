using System.Text.Json.Serialization;

namespace Courier.Net;

public class AutomationAddToDigestStep
{
    [JsonPropertyName("action")]
    public string Action { get; init; }

    /// <summary>
    /// The subscription topic that has digests enabled
    /// </summary>
    [JsonPropertyName("subscription_topic_id")]
    public string SubscriptionTopicId { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
