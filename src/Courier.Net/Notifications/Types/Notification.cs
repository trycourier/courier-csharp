using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record Notification
{
    [JsonPropertyName("created_at")]
    public required long CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public required long UpdatedAt { get; init; }

    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("routing")]
    public required MessageRouting Routing { get; init; }

    [JsonPropertyName("tags")]
    public NotificationTag? Tags { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("topic_id")]
    public required string TopicId { get; init; }
}
