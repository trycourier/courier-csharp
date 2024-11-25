using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record RoutingStrategyProvider
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("config")]
    public Dictionary<string, object?>? Config { get; set; }

    [JsonPropertyName("if")]
    public string? If { get; set; }

    [JsonPropertyName("metadata")]
    public required Metadata Metadata { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
