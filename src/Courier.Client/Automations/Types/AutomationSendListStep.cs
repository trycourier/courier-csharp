using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AutomationSendListStep
{
    [JsonPropertyName("action")]
    public required string Action { get; set; }

    [JsonPropertyName("brand")]
    public string? Brand { get; set; }

    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

    [JsonPropertyName("list")]
    public required string List { get; set; }

    [JsonPropertyName("override")]
    public Dictionary<string, object?>? Override { get; set; }

    [JsonPropertyName("template")]
    public string? Template { get; set; }

    [JsonPropertyName("if")]
    public string? If { get; set; }

    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
