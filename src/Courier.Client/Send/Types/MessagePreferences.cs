using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record MessagePreferences
{
    /// <summary>
    /// The ID of the subscription topic you want to apply to the message. If this is a templated message, it will override the subscription topic if already associated
    /// </summary>
    [JsonPropertyName("subscription_topic_id")]
    public required string SubscriptionTopicId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
