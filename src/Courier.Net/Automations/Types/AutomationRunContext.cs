using System.Text.Json.Serialization;

namespace Courier.Net;

public class AutomationRunContext
{
    [JsonPropertyName("brand")]
    public string? Brand { get; init; }

    [JsonPropertyName("data")]
    public object? Data { get; init; }

    [JsonPropertyName("profile")]
    public object? Profile { get; init; }

    [JsonPropertyName("template")]
    public string? Template { get; init; }

    [JsonPropertyName("recipient")]
    public string? Recipient { get; init; }
}
