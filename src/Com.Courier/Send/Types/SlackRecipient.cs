using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;
using OneOf;

#nullable enable

namespace Com.Courier;

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
