using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record DefaultPreferences
{
    [JsonPropertyName("items")]
    public IEnumerable<SubscriptionTopic>? Items { get; init; }
}
