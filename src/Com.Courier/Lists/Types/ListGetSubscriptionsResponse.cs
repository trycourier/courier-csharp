using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record ListGetSubscriptionsResponse
{
    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }

    [JsonPropertyName("items")]
    public IEnumerable<ListSubscriptionRecipient> Items { get; init; } =
        new List<ListSubscriptionRecipient>();
}
