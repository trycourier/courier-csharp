using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record Target
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }
}
