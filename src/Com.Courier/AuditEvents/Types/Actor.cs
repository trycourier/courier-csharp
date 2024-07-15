using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record Actor
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }
}
