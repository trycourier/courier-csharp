using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record AutomationV2SendStep
{
    [JsonPropertyName("action")]
    public required string Action { get; set; }

    [JsonPropertyName("message")]
    public required OneOf<ContentMessage, TemplateMessage> Message { get; set; }

    [JsonPropertyName("if")]
    public string? If { get; set; }

    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
