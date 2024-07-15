using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record Timeout
{
    [JsonPropertyName("provider")]
    public Dictionary<string, int>? Provider { get; init; }

    [JsonPropertyName("channel")]
    public Dictionary<string, int>? Channel { get; init; }

    [JsonPropertyName("message")]
    public int? Message { get; init; }

    [JsonPropertyName("escalation")]
    public int? Escalation { get; init; }

    [JsonPropertyName("criteria")]
    public Criteria? Criteria { get; init; }
}
