using System.Text.Json.Serialization;

namespace Courier.Net;

public class AutomationThrottleOnThrottle
{
    /// <summary>
    /// The node to go to if the request is throttled
    /// </summary>
    [JsonPropertyName("$node_id")]
    public string NodeId { get; init; }
}
