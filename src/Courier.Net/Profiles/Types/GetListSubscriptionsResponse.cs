using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class GetListSubscriptionsResponse
{
    [JsonPropertyName("paging")]
    public Paging Paging { get; init; }

    /// <summary>
    /// An array of lists
    /// </summary>
    [JsonPropertyName("results")]
    public List<GetListSubscriptionsList> Results { get; init; }
}
