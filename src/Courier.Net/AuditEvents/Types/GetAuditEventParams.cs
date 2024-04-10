using System.Text.Json.Serialization;

namespace Courier.Net;

public class GetAuditEventParams
{
    [JsonPropertyName("auditEventId")]
    public string AuditEventId { get; init; }
}
