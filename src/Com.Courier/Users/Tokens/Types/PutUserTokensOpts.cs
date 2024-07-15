using System.Text.Json.Serialization;
using Com.Courier.Users;

#nullable enable

namespace Com.Courier.Users;

public record PutUserTokensOpts
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; init; }

    [JsonPropertyName("tokens")]
    public IEnumerable<UserToken> Tokens { get; init; } = new List<UserToken>();
}
