using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ListAuditEventsResponse
{
    [JsonPropertyName("paging")]
    public required Paging Paging { get; set; }

    [JsonPropertyName("results")]
    public IEnumerable<AuditEvent> Results { get; set; } = new List<AuditEvent>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
