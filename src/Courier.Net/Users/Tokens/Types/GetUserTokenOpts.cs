using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net.Users;

public record GetUserTokenOpts
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; init; }

    [JsonPropertyName("token")]
    public required string Token { get; init; }
}
