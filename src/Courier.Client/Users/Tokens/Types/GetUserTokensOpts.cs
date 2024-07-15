using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client.Users;

public record GetUserTokensOpts
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; init; }
}
