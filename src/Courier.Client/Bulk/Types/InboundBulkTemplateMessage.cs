using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record InboundBulkTemplateMessage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The id of the notification template to be rendered and sent to the recipient(s).
    /// This field or the content field must be supplied.
    /// </summary>
    [JsonPropertyName("template")]
    public required string Template { get; set; }

    /// <summary>
    /// An arbitrary object that includes any data you want to pass to the message.
    /// The data will populate the corresponding template or elements variables.
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

    [JsonPropertyName("brand_id")]
    public string? BrandId { get; set; }

    /// <summary>
    /// "Define run-time configuration for one or more channels. If you don't specify channels, the default configuration for each channel will be used. Valid ChannelId's are: email, sms, push, inbox, direct_message, banner, and webhook."
    /// </summary>
    [JsonPropertyName("channels")]
    public Dictionary<string, Channel>? Channels { get; set; }

    /// <summary>
    /// Context to load with this recipient. Will override any context set on message.context.
    /// </summary>
    [JsonPropertyName("context")]
    public MessageContext? Context { get; set; }

    /// <summary>
    /// Metadata such as utm tracking attached with the notification through this channel.
    /// </summary>
    [JsonPropertyName("metadata")]
    public MessageMetadata? Metadata { get; set; }

    [JsonPropertyName("preferences")]
    public MessagePreferences? Preferences { get; set; }

    /// <summary>
    /// An object whose keys are valid provider identifiers which map to an object.
    /// </summary>
    [JsonPropertyName("providers")]
    public Dictionary<string, MessageProvidersType>? Providers { get; set; }

    [JsonPropertyName("routing")]
    public Routing? Routing { get; set; }

    /// <summary>
    /// Time in ms to attempt the channel before failing over to the next available channel.
    /// </summary>
    [JsonPropertyName("timeout")]
    public Timeout? Timeout { get; set; }

    /// <summary>
    /// Defines the time to wait before delivering the message. You can specify one of the following options. Duration with the number of milliseconds to delay. Until with an ISO 8601 timestamp that specifies when it should be delivered. Until with an OpenStreetMap opening_hours-like format that specifies the [Delivery Window](https://www.courier.com/docs/platform/sending/failover/#delivery-window) (e.g., 'Mo-Fr 08:00-18:00pm')
    /// </summary>
    [JsonPropertyName("delay")]
    public Delay? Delay { get; set; }

    /// <summary>
    /// "Expiry allows you to set an absolute or relative time in which a message expires.
    /// Note: This is only valid for the Courier Inbox channel as of 12-08-2022."
    /// </summary>
    [JsonPropertyName("expiry")]
    public Expiry? Expiry { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
