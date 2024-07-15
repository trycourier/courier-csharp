using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record Token
{
    [JsonPropertyName("token")]
    public required string Token_ { get; init; }
}
