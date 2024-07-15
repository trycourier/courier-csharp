using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record SnoozeRule
{
    [JsonPropertyName("type")]
    public required SnoozeRuleType Type { get; init; }

    [JsonPropertyName("start")]
    public required string Start { get; init; }

    [JsonPropertyName("until")]
    public required string Until { get; init; }
}
