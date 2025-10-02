using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

namespace Courier.Client;

[Serializable]
public record SendMessageRequest
{
    /// <summary>
    /// Defines the message to be delivered
    /// </summary>
    [JsonPropertyName("message")]
    public required OneOf<ContentMessage, TemplateMessage> Message { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
