using System.Text.Json.Serialization;

namespace Courier.Net;

public class AutomationSendListStep
{
    [JsonPropertyName("action")]
    public string Action { get; init; }

    [JsonPropertyName("brand")]
    public string? Brand { get; init; }

    [JsonPropertyName("data")]
    public Dictionary<string, object>? Data { get; init; }

    [JsonPropertyName("list")]
    public string List { get; init; }

    [JsonPropertyName("override")]
    public Dictionary<string, object>? Override { get; init; }

    [JsonPropertyName("template")]
    public string? Template { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
