using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record SnoozeRule
{
    [JsonPropertyName("type")]
    public required SnoozeRuleType Type { get; init; }

    [JsonPropertyName("start")]
    public required string Start { get; init; }

    [JsonPropertyName("until")]
    public required string Until { get; init; }
}
