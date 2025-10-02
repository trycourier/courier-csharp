using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

namespace Courier.Client;

[Serializable]
public record BaseMessageSendTo : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
