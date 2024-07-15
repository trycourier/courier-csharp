using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record AutomationThrottleOnThrottle
{
    /// <summary>
    /// The node to go to if the request is throttled
    /// </summary>
    [JsonPropertyName("$node_id")]
    public required string NodeId { get; init; }
}
