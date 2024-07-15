using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record Rule
{
    [JsonPropertyName("start")]
    public string? Start { get; init; }

    [JsonPropertyName("until")]
    public required string Until { get; init; }
}
