using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class NotificationTemplates
{
    /// <summary>
    /// A UTC timestamp at which notification was created. This is stored as a millisecond representation of the Unix epoch (the time passed since January 1, 1970).
    /// </summary>
    [JsonPropertyName("created_at")]
    public int CreatedAt { get; init; }

    /// <summary>
    /// A unique identifier associated with the notification.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; }

    /// <summary>
    /// Routing strategy used by this notification.
    /// </summary>
    [JsonPropertyName("routing")]
    public RoutingStrategy Routing { get; init; }

    /// <summary>
    /// A list of tags attached to the notification.
    /// </summary>
    [JsonPropertyName("tags")]
    public List<Tag> Tags { get; init; }

    /// <summary>
    /// The title of the notification.
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; init; }

    /// <summary>
    /// A UTC timestamp at which notification was updated. This is stored as a millisecond representation of the Unix epoch (the time passed since January 1, 1970).
    /// </summary>
    [JsonPropertyName("updated_at")]
    public int UpdatedAt { get; init; }
}
