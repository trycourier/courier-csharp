using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class BulkGetJobResponse
{
    [JsonPropertyName("job")]
    public JobDetails Job { get; init; }
}
