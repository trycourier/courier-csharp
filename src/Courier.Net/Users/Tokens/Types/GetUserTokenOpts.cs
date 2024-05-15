using System.Text.Json.Serialization;

namespace Courier.Net.Users;

public class GetUserTokenOpts
{
    [JsonPropertyName("user_id")]
    public string UserId { get; init; }

    [JsonPropertyName("token")]
    public string Token { get; init; }
}
