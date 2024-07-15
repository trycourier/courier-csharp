using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record SendMessageRequest
{
    /// <summary>
    /// Defines the message to be delivered
    /// </summary>
    [JsonPropertyName("message")]
    [JsonConverter(typeof(OneOfSerializer<OneOf<ContentMessage, TemplateMessage>>))]
    public required OneOf<ContentMessage, TemplateMessage> Message { get; init; }
}
