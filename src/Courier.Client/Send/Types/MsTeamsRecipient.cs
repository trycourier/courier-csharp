using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record MsTeamsRecipient
{
    [JsonPropertyName("ms_teams")]
    public required OneOf<
        SendToMsTeamsUserId,
        SendToMsTeamsEmail,
        SendToMsTeamsChannelId,
        SendToMsTeamsConversationId,
        SendToMsTeamsChannelName
    > MsTeams { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
