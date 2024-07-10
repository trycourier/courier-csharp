using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record AutomationInvokeResponse
{
    [JsonPropertyName("runId")]
    public required string RunId { get; init; }
}
