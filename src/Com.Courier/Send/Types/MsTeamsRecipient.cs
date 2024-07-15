using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;
using OneOf;

#nullable enable

namespace Com.Courier;

public record MsTeamsRecipient
{
    [JsonPropertyName("ms_teams")]
    [JsonConverter(
        typeof(OneOfSerializer<
            OneOf<
                SendToMsTeamsUserId,
                SendToMsTeamsEmail,
                SendToMsTeamsChannelId,
                SendToMsTeamsConversationId,
                SendToMsTeamsChannelName
            >
        >)
    )]
    public required OneOf<
        SendToMsTeamsUserId,
        SendToMsTeamsEmail,
        SendToMsTeamsChannelId,
        SendToMsTeamsConversationId,
        SendToMsTeamsChannelName
    > MsTeams { get; init; }
}
