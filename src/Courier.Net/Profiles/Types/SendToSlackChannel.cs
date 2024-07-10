using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record SendToSlackChannel
{
    [JsonPropertyName("channel")]
    public required string Channel { get; init; }

    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }
}
