using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record GetAuditEventParams
{
    [JsonPropertyName("auditEventId")]
    public required string AuditEventId { get; init; }
}
