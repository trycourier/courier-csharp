using System.Text.Json.Serialization;

namespace Courier.Net;

public class NotificationChannelContent
{
    [JsonPropertyName("subject")]
    public string? Subject { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }
}
