using System.Text.Json.Serialization;
using OneOf;
using Courier.Net;

namespace Courier.Net;

public class SlackRecipient
{
    [JsonPropertyName("slack")]
    public OneOf<SendToSlackChannel, SendToSlackEmail, SendToSlackUserId> Slack { get; init; }
}
