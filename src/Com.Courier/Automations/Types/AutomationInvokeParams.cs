using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record AutomationInvokeParams
{
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
