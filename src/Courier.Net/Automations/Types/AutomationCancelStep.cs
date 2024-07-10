using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record AutomationCancelStep
{
    [JsonPropertyName("action")]
    public required string Action { get; init; }

    [JsonPropertyName("cancelation_token")]
    public string? CancelationToken { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
