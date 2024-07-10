using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record AuditEvent
{
    [JsonPropertyName("actor")]
    public Actor? Actor { get; init; }

    [JsonPropertyName("target")]
    public Target? Target { get; init; }

    [JsonPropertyName("auditEventId")]
    public required string AuditEventId { get; init; }

    [JsonPropertyName("source")]
    public required string Source { get; init; }

    [JsonPropertyName("timestamp")]
    public required string Timestamp { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }
}
