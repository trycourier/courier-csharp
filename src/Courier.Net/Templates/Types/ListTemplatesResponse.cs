using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class ListTemplatesResponse
{
    [JsonPropertyName("paging")]
    public Paging Paging { get; init; }

    /// <summary>
    /// An array of Notification Templates
    /// </summary>
    [JsonPropertyName("results")]
    public List<NotificationTemplates> Results { get; init; }
}
