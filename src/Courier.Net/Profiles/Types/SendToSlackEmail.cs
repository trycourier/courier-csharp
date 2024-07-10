using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record SendToSlackEmail
{
    [JsonPropertyName("email")]
    public required string Email { get; init; }

    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }
}
