using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net.Users;

public record GetUserTokensOpts
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; init; }
}
