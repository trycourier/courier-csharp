using System.Text.Json.Serialization;
using Com.Courier.Users;

#nullable enable

namespace Com.Courier.Users;

public record PutUserTokenOpts
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; init; }

    [JsonPropertyName("token")]
    public required UserToken Token { get; init; }
}
