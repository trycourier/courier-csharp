using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record AutomationV2SendStep
{
    [JsonPropertyName("action")]
    public required string Action { get; init; }

    [JsonPropertyName("message")]
    [JsonConverter(typeof(OneOfSerializer<OneOf<ContentMessage, TemplateMessage>>))]
    public required OneOf<ContentMessage, TemplateMessage> Message { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
