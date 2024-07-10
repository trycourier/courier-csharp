using System.Text.Json.Serialization;
using Courier.Net.Users;

#nullable enable

namespace Courier.Net.Users;

public record PutUserTokensOpts
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; init; }

    [JsonPropertyName("tokens")]
    public IEnumerable<UserToken> Tokens { get; init; } = new List<UserToken>();
}
