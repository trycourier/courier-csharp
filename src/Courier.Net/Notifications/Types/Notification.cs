using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class Notification
{
    [JsonPropertyName("created_at")]
    public long CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public long UpdatedAt { get; init; }

    [JsonPropertyName("id")]
    public string Id { get; init; }

    [JsonPropertyName("routing")]
    public MessageRouting Routing { get; init; }

    [JsonPropertyName("tags")]
    public NotificationTag? Tags { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("topic_id")]
    public string TopicId { get; init; }
}
