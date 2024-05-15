using System.Text.Json.Serialization;

namespace Courier.Net;

public class BulkGetJobParams
{
    [JsonPropertyName("jobId")]
    public string JobId { get; init; }
}
