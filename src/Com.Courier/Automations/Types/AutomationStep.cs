using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record AutomationStep
{
    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
