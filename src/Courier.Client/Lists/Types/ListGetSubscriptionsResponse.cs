using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ListGetSubscriptionsResponse
{
    [JsonPropertyName("paging")]
    public required Paging Paging { get; set; }

    [JsonPropertyName("items")]
    public IEnumerable<ListSubscriptionRecipient> Items { get; set; } =
        new List<ListSubscriptionRecipient>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
