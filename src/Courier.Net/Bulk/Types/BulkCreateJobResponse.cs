using System.Text.Json.Serialization;

namespace Courier.Net;

public class BulkCreateJobResponse
{
    [JsonPropertyName("jobId")]
    public string JobId { get; init; }
}
