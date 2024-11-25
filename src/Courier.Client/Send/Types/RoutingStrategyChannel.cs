using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record RoutingStrategyChannel
{
    [JsonPropertyName("channel")]
    public required string Channel { get; set; }

    [JsonPropertyName("config")]
    public Dictionary<string, object?>? Config { get; set; }

    [JsonPropertyName("method")]
    public RoutingMethod? Method { get; set; }

    [JsonPropertyName("providers")]
    public Dictionary<string, MessageProvidersType>? Providers { get; set; }

    [JsonPropertyName("if")]
    public string? If { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
