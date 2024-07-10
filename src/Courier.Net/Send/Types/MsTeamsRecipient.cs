using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;
using OneOf;

#nullable enable

namespace Courier.Net;

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
