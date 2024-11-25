using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record BaseMessageSendTo
{
    /// <summary>
    /// The recipient or a list of recipients of the message
    /// </summary>
    [JsonPropertyName("to")]
    public OneOf<
        OneOf<
            AudienceRecipient,
            ListRecipient,
            ListPatternRecipient,
            UserRecipient,
            SlackRecipient,
            MsTeamsRecipient,
            Dictionary<string, object?>,
            PagerdutyRecipient,
            WebhookRecipient
        >,
        IEnumerable<
            OneOf<
                AudienceRecipient,
                ListRecipient,
                ListPatternRecipient,
                UserRecipient,
                SlackRecipient,
                MsTeamsRecipient,
                Dictionary<string, object?>,
                PagerdutyRecipient,
                WebhookRecipient
            >
        >
    >? To { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
