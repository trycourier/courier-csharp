using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record BulkCreateJobResponse
{
    [JsonPropertyName("jobId")]
    public required string JobId { get; init; }
}
