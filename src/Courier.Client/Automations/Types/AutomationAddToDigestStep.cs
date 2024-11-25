using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AutomationAddToDigestStep
{
    [JsonPropertyName("action")]
    public required string Action { get; set; }

    /// <summary>
    /// The subscription topic that has digests enabled
    /// </summary>
    [JsonPropertyName("subscription_topic_id")]
    public required string SubscriptionTopicId { get; set; }

    [JsonPropertyName("if")]
    public string? If { get; set; }

    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
