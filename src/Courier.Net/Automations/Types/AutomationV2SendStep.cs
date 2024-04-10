using System.Text.Json.Serialization;
using OneOf;
using Courier.Net;

namespace Courier.Net;

public class AutomationV2SendStep
{
    [JsonPropertyName("action")]
    public string Action { get; init; }

    [JsonPropertyName("message")]
    public OneOf<ContentMessage, TemplateMessage> Message { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
