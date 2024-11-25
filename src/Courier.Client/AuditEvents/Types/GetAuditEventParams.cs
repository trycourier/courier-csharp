using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record GetAuditEventParams
{
    [JsonPropertyName("auditEventId")]
    public required string AuditEventId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
