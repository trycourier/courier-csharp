using System.Text.Json.Serialization;
using OneOf;
using Courier.Net;

namespace Courier.Net;

public class MsTeamsRecipient
{
    [JsonPropertyName("ms_teams")]
    public OneOf<SendToMsTeamsUserId, SendToMsTeamsEmail, SendToMsTeamsChannelId, SendToMsTeamsConversationId, SendToMsTeamsChannelName> MsTeams { get; init; }
}
