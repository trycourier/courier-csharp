using System.Text.Json.Serialization;
using Courier.Net.Users;

namespace Courier.Net.Users;

public class UserPreferencesGetResponse
{
    [JsonPropertyName("topic")]
    public TopicPreference Topic { get; init; }
}
