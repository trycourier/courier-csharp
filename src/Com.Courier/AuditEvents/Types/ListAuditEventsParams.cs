using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record ListAuditEventsParams
{
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }
}
