using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record ListAuditEventsResponse
{
    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }

    [JsonPropertyName("results")]
    public IEnumerable<AuditEvent> Results { get; init; } = new List<AuditEvent>();
}
