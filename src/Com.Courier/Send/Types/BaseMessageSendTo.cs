using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;
using OneOf;

#nullable enable

namespace Com.Courier;

public record BaseMessageSendTo
{
    /// <summary>
    /// The recipient or a list of recipients of the message
    /// </summary>
    [JsonPropertyName("to")]
    [JsonConverter(
        typeof(OneOfSerializer<
            OneOf<
                OneOf<
                    AudienceRecipient,
                    ListRecipient,
                    ListPatternRecipient,
                    UserRecipient,
                    SlackRecipient,
                    MsTeamsRecipient,
                    Dictionary<string, object>
                >,
                IEnumerable<
                    OneOf<
                        AudienceRecipient,
                        ListRecipient,
                        ListPatternRecipient,
                        UserRecipient,
                        SlackRecipient,
                        MsTeamsRecipient,
                        Dictionary<string, object>
                    >
                >
            >
        >)
    )]
    public OneOf<
        OneOf<
            AudienceRecipient,
            ListRecipient,
            ListPatternRecipient,
            UserRecipient,
            SlackRecipient,
            MsTeamsRecipient,
            Dictionary<string, object>
        >,
        IEnumerable<
            OneOf<
                AudienceRecipient,
                ListRecipient,
                ListPatternRecipient,
                UserRecipient,
                SlackRecipient,
                MsTeamsRecipient,
                Dictionary<string, object>
            >
        >
    >? To { get; init; }
}
