using System.Text.Json.Serialization;
using Courier.Client;
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
