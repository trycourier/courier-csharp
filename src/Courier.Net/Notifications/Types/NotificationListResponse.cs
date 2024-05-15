using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class NotificationListResponse
{
    [JsonPropertyName("paging")]
    public Paging Paging { get; init; }

    [JsonPropertyName("results")]
    public List<Notification> Results { get; init; }
}
