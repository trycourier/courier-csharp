using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record RoutingStrategyChannel
{
    [JsonPropertyName("channel")]
    public required string Channel { get; init; }

    [JsonPropertyName("config")]
    public Dictionary<string, object>? Config { get; init; }

    [JsonPropertyName("method")]
    public RoutingMethod? Method { get; init; }

    [JsonPropertyName("providers")]
    public Dictionary<string, MessageProvidersType>? Providers { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }
}
