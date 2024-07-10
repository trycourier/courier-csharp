using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record SnoozeRule
{
    [JsonPropertyName("type")]
    public required SnoozeRuleType Type { get; init; }

    [JsonPropertyName("start")]
    public required string Start { get; init; }

    [JsonPropertyName("until")]
    public required string Until { get; init; }
}
