using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record ListAuditEventsParams
{
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }
}
