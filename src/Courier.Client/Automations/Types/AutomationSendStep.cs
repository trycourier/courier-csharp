using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record AutomationSendStep
{
    [JsonPropertyName("action")]
    public required string Action { get; init; }

    [JsonPropertyName("brand")]
    public string? Brand { get; init; }

    [JsonPropertyName("data")]
    public Dictionary<string, object>? Data { get; init; }

    [JsonPropertyName("override")]
    public Dictionary<string, object>? Override { get; init; }

    [JsonPropertyName("profile")]
    public object? Profile { get; init; }

    [JsonPropertyName("recipient")]
    public string? Recipient { get; init; }

    [JsonPropertyName("template")]
    public string? Template { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
