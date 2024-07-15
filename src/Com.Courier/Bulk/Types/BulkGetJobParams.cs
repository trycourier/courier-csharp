using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record BulkGetJobParams
{
    [JsonPropertyName("jobId")]
    public required string JobId { get; init; }
}
