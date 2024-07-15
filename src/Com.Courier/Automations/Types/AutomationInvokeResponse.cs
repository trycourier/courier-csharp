using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record AutomationInvokeResponse
{
    [JsonPropertyName("runId")]
    public required string RunId { get; init; }
}
