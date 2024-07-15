using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record BulkCreateJobResponse
{
    [JsonPropertyName("jobId")]
    public required string JobId { get; init; }
}
