using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

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
