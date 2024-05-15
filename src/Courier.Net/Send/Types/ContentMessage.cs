using System.Text.Json.Serialization;
using OneOf;
using Courier.Net;

namespace Courier.Net;

public class ContentMessage
{
    /// <summary>
    /// Describes the content of the message in a way that will work for email, push,
    /// chat, or any channel. Either this or template must be specified.
    /// </summary>
    [JsonPropertyName("content")]
    public OneOf<ElementalContent, ElementalContentSugar> Content { get; init; }

    /// <summary>
    /// An arbitrary object that includes any data you want to pass to the message.
    /// The data will populate the corresponding template or elements variables.
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object>? Data { get; init; }

    [JsonPropertyName("brand_id")]
    public string? BrandId { get; init; }

    /// <summary>
    /// "Define run-time configuration for one or more channels. If you don't specify channels, the default configuration for each channel will be used. Valid ChannelId's are: email, sms, push, inbox, direct_message, banner, and webhook."
    /// </summary>
    [JsonPropertyName("channels")]
    public Dictionary<string, Channel>? Channels { get; init; }

    /// <summary>
    /// Context to load with this recipient. Will override any context set on message.context.
    /// </summary>
    [JsonPropertyName("context")]
    public MessageContext? Context { get; init; }

    /// <summary>
    /// Metadata such as utm tracking attached with the notification through this channel.
    /// </summary>
    [JsonPropertyName("metadata")]
    public MessageMetadata? Metadata { get; init; }

    /// <summary>
    /// An object whose keys are valid provider identifiers which map to an object.
    /// </summary>
    [JsonPropertyName("providers")]
    public Dictionary<string, MessageProvidersType>? Providers { get; init; }

    [JsonPropertyName("routing")]
    public Routing? Routing { get; init; }

    /// <summary>
    /// Time in ms to attempt the channel before failing over to the next available channel.
    /// </summary>
    [JsonPropertyName("timeout")]
    public Timeout? Timeout { get; init; }

    /// <summary>
    /// Defines the time to wait before delivering the message.
    /// </summary>
    [JsonPropertyName("delay")]
    public Delay? Delay { get; init; }

    /// <summary>
    /// "Expiry allows you to set an absolute or relative time in which a message expires.
    /// Note: This is only valid for the Courier Inbox channel as of 12-08-2022."
    /// </summary>
    [JsonPropertyName("expiry")]
    public Expiry? Expiry { get; init; }

    /// <summary>
    /// The recipient or a list of recipients of the message
    /// </summary>
    [JsonPropertyName("to")]
    public OneOf<OneOf<AudienceRecipient, ListRecipient, ListPatternRecipient, UserRecipient, SlackRecipient, MsTeamsRecipient, Dictionary<string, object>>, List<OneOf<AudienceRecipient, ListRecipient, ListPatternRecipient, UserRecipient, SlackRecipient, MsTeamsRecipient, Dictionary<string, object>>>>? To { get; init; }
}
