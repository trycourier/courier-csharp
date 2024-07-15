using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record SendToSlackUserId
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; init; }

    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }
}
