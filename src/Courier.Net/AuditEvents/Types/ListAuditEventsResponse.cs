using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class ListAuditEventsResponse
{
    [JsonPropertyName("paging")]
    public Paging Paging { get; init; }

    [JsonPropertyName("results")]
    public List<AuditEvent> Results { get; init; }
}
