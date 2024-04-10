using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class RoutingStrategyChannel
{
    [JsonPropertyName("channel")]
    public string Channel { get; init; }

    [JsonPropertyName("config")]
    public Dictionary<string, object>? Config { get; init; }

    [JsonPropertyName("method")]
    public RoutingMethod? Method { get; init; }

    [JsonPropertyName("providers")]
    public Dictionary<string, MessageProvidersType>? Providers { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }
}
