using System.Text.Json.Serialization;
using Courier.Client.Users;

#nullable enable

namespace Courier.Client.Users;

public record PutUserTokenOpts
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; init; }

    [JsonPropertyName("token")]
    public required UserToken Token { get; init; }
}
