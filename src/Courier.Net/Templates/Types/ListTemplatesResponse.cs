using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record ListTemplatesResponse
{
    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }

    /// <summary>
    /// An array of Notification Templates
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<NotificationTemplates> Results { get; init; } =
        new List<NotificationTemplates>();
}
