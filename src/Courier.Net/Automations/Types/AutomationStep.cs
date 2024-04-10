using System.Text.Json.Serialization;

namespace Courier.Net;

public class AutomationStep
{
    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
