using System.Text.Json.Serialization;
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
    public required OneOf<ContentMessage, TemplateMessage> Message { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
