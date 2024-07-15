using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record Token
{
    [JsonPropertyName("token")]
    public required string Token_ { get; init; }
}
