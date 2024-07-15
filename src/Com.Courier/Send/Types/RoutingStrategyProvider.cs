using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record RoutingStrategyProvider
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("config")]
    public Dictionary<string, object>? Config { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("metadata")]
    public required Metadata Metadata { get; init; }
}
