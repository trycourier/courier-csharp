using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record SlackRecipient
{
    [JsonPropertyName("slack")]
    public required OneOf<
        SendToSlackChannel,
        SendToSlackEmail,
        SendToSlackUserId
    > Slack { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
