using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AutomationThrottleOnThrottle
{
    /// <summary>
    /// The node to go to if the request is throttled
    /// </summary>
    [JsonPropertyName("$node_id")]
    public required string NodeId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
