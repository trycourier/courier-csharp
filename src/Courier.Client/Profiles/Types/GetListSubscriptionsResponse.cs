using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record GetListSubscriptionsResponse
{
    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }

    /// <summary>
    /// An array of lists
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<GetListSubscriptionsList> Results { get; init; } =
        new List<GetListSubscriptionsList>();
}
