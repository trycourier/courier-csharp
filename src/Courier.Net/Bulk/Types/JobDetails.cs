using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class JobDetails
{
    [JsonPropertyName("definition")]
    public InboundBulkMessage Definition { get; init; }

    [JsonPropertyName("enqueued")]
    public int Enqueued { get; init; }

    [JsonPropertyName("failures")]
    public int Failures { get; init; }

    [JsonPropertyName("received")]
    public int Received { get; init; }

    [JsonPropertyName("status")]
    public BulkJobStatus Status { get; init; }
}
