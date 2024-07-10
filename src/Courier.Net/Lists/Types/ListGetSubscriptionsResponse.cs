using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record ListGetSubscriptionsResponse
{
    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }

    [JsonPropertyName("items")]
    public IEnumerable<ListSubscriptionRecipient> Items { get; init; } =
        new List<ListSubscriptionRecipient>();
}
