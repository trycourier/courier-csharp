using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record Icons
{
    [JsonPropertyName("bell")]
    public string? Bell { get; init; }

    [JsonPropertyName("message")]
    public string? Message { get; init; }
}
