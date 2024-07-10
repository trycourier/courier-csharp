using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record BulkGetJobParams
{
    [JsonPropertyName("jobId")]
    public required string JobId { get; init; }
}
