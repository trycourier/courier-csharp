using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier.Users;

public record GetUserTokensOpts
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; init; }
}
