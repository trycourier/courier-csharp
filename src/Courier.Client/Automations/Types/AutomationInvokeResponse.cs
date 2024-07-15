using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record AutomationInvokeResponse
{
    [JsonPropertyName("runId")]
    public required string RunId { get; init; }
}
