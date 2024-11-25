using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AutomationInvokeTemplateParams
{
    [JsonPropertyName("templateId")]
    public required string TemplateId { get; set; }

    [JsonPropertyName("brand")]
    public string? Brand { get; set; }

    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

    [JsonPropertyName("profile")]
    public object? Profile { get; set; }

    [JsonPropertyName("recipient")]
    public string? Recipient { get; set; }

    [JsonPropertyName("template")]
    public string? Template { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
