using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class DefaultPreferences
{
    [JsonPropertyName("items")]
    public List<SubscriptionTopic> Items { get; init; }
}
