using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record BulkCreateJobResponse
{
    [JsonPropertyName("jobId")]
    public required string JobId { get; init; }
}
