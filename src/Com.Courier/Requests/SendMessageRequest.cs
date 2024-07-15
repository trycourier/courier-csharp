using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;
using OneOf;

#nullable enable

namespace Com.Courier;

public record SendMessageRequest
{
    /// <summary>
    /// Defines the message to be delivered
    /// </summary>
    [JsonPropertyName("message")]
    [JsonConverter(typeof(OneOfSerializer<OneOf<ContentMessage, TemplateMessage>>))]
    public required OneOf<ContentMessage, TemplateMessage> Message { get; init; }
}
