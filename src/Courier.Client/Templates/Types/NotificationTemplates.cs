using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record NotificationTemplates
{
    /// <summary>
    /// A UTC timestamp at which notification was created. This is stored as a millisecond representation of the Unix epoch (the time passed since January 1, 1970).
    /// </summary>
    [JsonPropertyName("created_at")]
    public required long CreatedAt { get; set; }

    /// <summary>
    /// A unique identifier associated with the notification.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Routing strategy used by this notification.
    /// </summary>
    [JsonPropertyName("routing")]
    public required RoutingStrategy Routing { get; set; }

    /// <summary>
    /// A list of tags attached to the notification.
    /// </summary>
    [JsonPropertyName("tags")]
    public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();

    /// <summary>
    /// The title of the notification.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// A UTC timestamp at which notification was updated. This is stored as a millisecond representation of the Unix epoch (the time passed since January 1, 1970).
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required long UpdatedAt { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
