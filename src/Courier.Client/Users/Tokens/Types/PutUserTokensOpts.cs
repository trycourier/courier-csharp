using System.Text.Json.Serialization;
using Courier.Client.Users;

#nullable enable

namespace Courier.Client.Users;

public record PutUserTokensOpts
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; init; }

    [JsonPropertyName("tokens")]
    public IEnumerable<UserToken> Tokens { get; init; } = new List<UserToken>();
}
