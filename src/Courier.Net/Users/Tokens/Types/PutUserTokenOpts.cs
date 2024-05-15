using System.Text.Json.Serialization;
using Courier.Net.Users;

namespace Courier.Net.Users;

public class PutUserTokenOpts
{
    [JsonPropertyName("user_id")]
    public string UserId { get; init; }

    [JsonPropertyName("token")]
    public UserToken Token { get; init; }
}
