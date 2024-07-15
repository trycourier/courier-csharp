using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record SlackBaseProperties
{
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }
}
