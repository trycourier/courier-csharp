using System.Text.Json.Serialization;

namespace Courier.Net.Users;

public class GetUserTokensOpts
{
    [JsonPropertyName("user_id")]
    public string UserId { get; init; }
}
