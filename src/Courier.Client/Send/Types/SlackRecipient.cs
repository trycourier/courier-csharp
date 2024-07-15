using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record SlackRecipient
{
    [JsonPropertyName("slack")]
    [JsonConverter(
        typeof(OneOfSerializer<OneOf<SendToSlackChannel, SendToSlackEmail, SendToSlackUserId>>)
    )]
    public required OneOf<
        SendToSlackChannel,
        SendToSlackEmail,
        SendToSlackUserId
    > Slack { get; init; }
}
