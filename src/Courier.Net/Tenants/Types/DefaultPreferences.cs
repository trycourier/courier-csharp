using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record DefaultPreferences
{
    [JsonPropertyName("items")]
    public IEnumerable<SubscriptionTopic>? Items { get; init; }
}
