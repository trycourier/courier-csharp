using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record GetAuditEventParams
{
    [JsonPropertyName("auditEventId")]
    public required string AuditEventId { get; init; }
}
