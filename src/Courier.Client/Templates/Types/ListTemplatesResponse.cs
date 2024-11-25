using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ListTemplatesResponse
{
    [JsonPropertyName("paging")]
    public required Paging Paging { get; set; }

    /// <summary>
    /// An array of Notification Templates
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<NotificationTemplates> Results { get; set; } =
        new List<NotificationTemplates>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
