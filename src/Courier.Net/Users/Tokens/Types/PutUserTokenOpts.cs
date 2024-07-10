using System.Text.Json.Serialization;
using Courier.Net.Users;

#nullable enable

namespace Courier.Net.Users;

public record PutUserTokenOpts
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; init; }

    [JsonPropertyName("token")]
    public required UserToken Token { get; init; }
}
