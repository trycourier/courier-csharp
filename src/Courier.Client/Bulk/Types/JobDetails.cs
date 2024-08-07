using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record JobDetails
{
    [JsonPropertyName("definition")]
    public required InboundBulkMessage Definition { get; init; }

    [JsonPropertyName("enqueued")]
    public required int Enqueued { get; init; }

    [JsonPropertyName("failures")]
    public required int Failures { get; init; }

    [JsonPropertyName("received")]
    public required int Received { get; init; }

    [JsonPropertyName("status")]
    public required BulkJobStatus Status { get; init; }
}
