using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record AutomationInvokeStep
{
    [JsonPropertyName("action")]
    public required string Action { get; init; }

    [JsonPropertyName("template")]
    public required string Template { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
