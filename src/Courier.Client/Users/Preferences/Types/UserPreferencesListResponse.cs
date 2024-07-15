using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Users;

#nullable enable

namespace Courier.Client.Users;

public record UserPreferencesListResponse
{
    /// <summary>
    /// Deprecated - Paging not implemented on this endpoint
    /// </summary>
    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }

    /// <summary>
    /// The Preferences associated with the user_id.
    /// </summary>
    [JsonPropertyName("items")]
    public IEnumerable<TopicPreference> Items { get; init; } = new List<TopicPreference>();
}
