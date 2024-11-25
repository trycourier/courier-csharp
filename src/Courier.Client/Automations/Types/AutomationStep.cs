using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AutomationStep
{
    [JsonPropertyName("if")]
    public string? If { get; set; }

    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
