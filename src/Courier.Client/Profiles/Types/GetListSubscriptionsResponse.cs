using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record GetListSubscriptionsResponse
{
    [JsonPropertyName("paging")]
    public required Paging Paging { get; set; }

    /// <summary>
    /// An array of lists
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<GetListSubscriptionsList> Results { get; set; } =
        new List<GetListSubscriptionsList>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
