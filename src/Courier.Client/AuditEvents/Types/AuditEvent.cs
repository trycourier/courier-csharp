using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AuditEvent
{
    [JsonPropertyName("actor")]
    public Actor? Actor { get; set; }

    [JsonPropertyName("target")]
    public Target? Target { get; set; }

    [JsonPropertyName("auditEventId")]
    public required string AuditEventId { get; set; }

    [JsonPropertyName("source")]
    public required string Source { get; set; }

    [JsonPropertyName("timestamp")]
    public required string Timestamp { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
