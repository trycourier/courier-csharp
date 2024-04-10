using System.Text.Json.Serialization;
using OneOf;
using Courier.Net;

namespace Courier.Net;

public class BaseMessageSendTo
{
    /// <summary>
    /// The recipient or a list of recipients of the message
    /// </summary>
    [JsonPropertyName("to")]
    public OneOf<OneOf<AudienceRecipient, ListRecipient, ListPatternRecipient, UserRecipient, SlackRecipient, MsTeamsRecipient, Dictionary<string, object>>, List<OneOf<AudienceRecipient, ListRecipient, ListPatternRecipient, UserRecipient, SlackRecipient, MsTeamsRecipient, Dictionary<string, object>>>>? To { get; init; }
}
