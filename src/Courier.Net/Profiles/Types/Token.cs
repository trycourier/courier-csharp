using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record Token
{
    [JsonPropertyName("token")]
    public required string Token_ { get; init; }
}
