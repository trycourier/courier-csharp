using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record Pagerduty
{
    [JsonPropertyName("routing_key")]
    public string? RoutingKey { get; set; }

    [JsonPropertyName("event_action")]
    public string? EventAction { get; set; }

    [JsonPropertyName("severity")]
    public string? Severity { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
