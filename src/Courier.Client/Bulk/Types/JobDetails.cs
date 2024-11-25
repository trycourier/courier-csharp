using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record JobDetails
{
    [JsonPropertyName("definition")]
    public required InboundBulkMessage Definition { get; set; }

    [JsonPropertyName("enqueued")]
    public required int Enqueued { get; set; }

    [JsonPropertyName("failures")]
    public required int Failures { get; set; }

    [JsonPropertyName("received")]
    public required int Received { get; set; }

    [JsonPropertyName("status")]
    public required BulkJobStatus Status { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
