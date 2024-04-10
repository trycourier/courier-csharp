using System.Text.Json.Serialization;

namespace Courier.Net;

public class ListAuditEventsParams
{
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }
}
