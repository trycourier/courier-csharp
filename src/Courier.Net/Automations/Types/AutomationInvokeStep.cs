using System.Text.Json.Serialization;

namespace Courier.Net;

public class AutomationInvokeStep
{
    [JsonPropertyName("action")]
    public string Action { get; init; }

    [JsonPropertyName("template")]
    public string Template { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
