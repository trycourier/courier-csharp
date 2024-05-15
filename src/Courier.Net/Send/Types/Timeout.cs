using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class Timeout
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
