using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record SlackBaseProperties
{
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }
}
