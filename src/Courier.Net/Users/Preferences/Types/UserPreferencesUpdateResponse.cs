using System.Text.Json.Serialization;

namespace Courier.Net.Users;

public class UserPreferencesUpdateResponse
{
    [JsonPropertyName("message")]
    public string Message { get; init; }
}
