using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class SnoozeRule
{
    [JsonPropertyName("type")]
    public SnoozeRuleType Type { get; init; }

    [JsonPropertyName("start")]
    public string Start { get; init; }

    [JsonPropertyName("until")]
    public string Until { get; init; }
}
