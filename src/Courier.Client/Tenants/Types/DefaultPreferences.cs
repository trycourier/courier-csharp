using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record DefaultPreferences
{
    [JsonPropertyName("items")]
    public IEnumerable<SubscriptionTopic>? Items { get; init; }
}
