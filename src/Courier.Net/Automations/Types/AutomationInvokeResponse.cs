using System.Text.Json.Serialization;

namespace Courier.Net;

public class AutomationInvokeResponse
{
    [JsonPropertyName("runId")]
    public string RunId { get; init; }
}
