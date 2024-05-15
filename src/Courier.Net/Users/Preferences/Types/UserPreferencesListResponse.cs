using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Users;

namespace Courier.Net.Users;

public class UserPreferencesListResponse
{
    [JsonPropertyName("paging")]
    public Paging Paging { get; init; }

    /// <summary>
    /// The Preferences associated with the user_id.
    /// </summary>
    [JsonPropertyName("items")]
    public List<TopicPreference> Items { get; init; }
}
