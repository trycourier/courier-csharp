using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class AutomationAdHocInvokeParams
{
    [JsonPropertyName("automation")]
    public Automation Automation { get; init; }

    [JsonPropertyName("brand")]
    public string? Brand { get; init; }

    [JsonPropertyName("data")]
    public Dictionary<string, object>? Data { get; init; }

    [JsonPropertyName("profile")]
    public object? Profile { get; init; }

    [JsonPropertyName("recipient")]
    public string? Recipient { get; init; }

    [JsonPropertyName("template")]
    public string? Template { get; init; }
}
