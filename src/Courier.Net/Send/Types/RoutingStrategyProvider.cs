using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class RoutingStrategyProvider
{
    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("config")]
    public Dictionary<string, object>? Config { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("metadata")]
    public Metadata Metadata { get; init; }
}
