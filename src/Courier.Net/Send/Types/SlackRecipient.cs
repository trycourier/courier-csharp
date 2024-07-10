using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;
using OneOf;

#nullable enable

namespace Courier.Net;

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
