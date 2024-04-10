using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class AuditEvent
{
    [JsonPropertyName("actor")]
    public Actor? Actor { get; init; }

    [JsonPropertyName("target")]
    public Target? Target { get; init; }

    [JsonPropertyName("auditEventId")]
    public string AuditEventId { get; init; }

    [JsonPropertyName("source")]
    public string Source { get; init; }

    [JsonPropertyName("timestamp")]
    public string Timestamp { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; }
}
