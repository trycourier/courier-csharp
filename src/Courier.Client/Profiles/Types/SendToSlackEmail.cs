using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record SendToSlackEmail
{
    [JsonPropertyName("email")]
    public required string Email { get; init; }

    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }
}
