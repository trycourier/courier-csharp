using System.Text.Json.Serialization;

namespace Courier.Net;

public class AutomationCancelStep
{
    [JsonPropertyName("action")]
    public string Action { get; init; }

    [JsonPropertyName("cancelation_token")]
    public string? CancelationToken { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
