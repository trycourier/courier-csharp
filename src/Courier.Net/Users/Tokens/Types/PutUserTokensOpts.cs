using System.Text.Json.Serialization;
using Courier.Net.Users;

namespace Courier.Net.Users;

public class PutUserTokensOpts
{
    [JsonPropertyName("user_id")]
    public string UserId { get; init; }

    [JsonPropertyName("tokens")]
    public List<UserToken> Tokens { get; init; }
}
