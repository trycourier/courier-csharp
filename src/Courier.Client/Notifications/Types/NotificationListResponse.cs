using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record NotificationListResponse
{
    [JsonPropertyName("paging")]
    public required Paging Paging { get; set; }

    [JsonPropertyName("results")]
    public IEnumerable<Notification> Results { get; set; } = new List<Notification>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
