using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class SubscriptionTopic
{
    /// <summary>
    /// Topic ID
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; }

    [JsonPropertyName("status")]
    public SubscriptionTopicStatus Status { get; init; }
}
