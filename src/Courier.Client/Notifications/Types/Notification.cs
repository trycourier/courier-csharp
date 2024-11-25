using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record Notification
{
    [JsonPropertyName("created_at")]
    public required long CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public required long UpdatedAt { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("routing")]
    public required MessageRouting Routing { get; set; }

    [JsonPropertyName("tags")]
    public NotificationTag? Tags { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("topic_id")]
    public required string TopicId { get; set; }

    [JsonPropertyName("note")]
    public required string Note { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
