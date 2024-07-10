using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record BulkGetJobUsersParams
{
    [JsonPropertyName("jobId")]
    public required string JobId { get; init; }

    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }
}
