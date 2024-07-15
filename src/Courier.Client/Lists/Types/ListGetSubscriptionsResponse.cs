using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record ListGetSubscriptionsResponse
{
    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }

    [JsonPropertyName("items")]
    public IEnumerable<ListSubscriptionRecipient> Items { get; init; } =
        new List<ListSubscriptionRecipient>();
}
