using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class ListGetSubscriptionsResponse
{
    [JsonPropertyName("paging")]
    public Paging Paging { get; init; }

    [JsonPropertyName("items")]
    public List<ListSubscriptionRecipient> Items { get; init; }
}
