using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record NotificationTemplates
{
    /// <summary>
    /// A UTC timestamp at which notification was created. This is stored as a millisecond representation of the Unix epoch (the time passed since January 1, 1970).
    /// </summary>
    [JsonPropertyName("created_at")]
    public required int CreatedAt { get; init; }

    /// <summary>
    /// A unique identifier associated with the notification.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// Routing strategy used by this notification.
    /// </summary>
    [JsonPropertyName("routing")]
    public required RoutingStrategy Routing { get; init; }

    /// <summary>
    /// A list of tags attached to the notification.
    /// </summary>
    [JsonPropertyName("tags")]
    public IEnumerable<Tag> Tags { get; init; } = new List<Tag>();

    /// <summary>
    /// The title of the notification.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; init; }

    /// <summary>
    /// A UTC timestamp at which notification was updated. This is stored as a millisecond representation of the Unix epoch (the time passed since January 1, 1970).
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required int UpdatedAt { get; init; }
}
