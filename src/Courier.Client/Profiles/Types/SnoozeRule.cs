using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record SnoozeRule
{
    [JsonPropertyName("type")]
    public required SnoozeRuleType Type { get; set; }

    [JsonPropertyName("start")]
    public required string Start { get; set; }

    [JsonPropertyName("until")]
    public required string Until { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
