using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

namespace Courier.Client.Users;

[Serializable]
public record TopicPreference : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The Channels a user has chosen to receive notifications through for this topic
    /// </summary>
    [JsonPropertyName("custom_routing")]
    public IEnumerable<ChannelClassification>? CustomRouting { get; set; }

    [JsonPropertyName("default_status")]
    public required PreferenceStatus DefaultStatus { get; set; }

    [JsonPropertyName("has_custom_routing")]
    public bool? HasCustomRouting { get; set; }

    [JsonPropertyName("status")]
    public required PreferenceStatus Status { get; set; }

    [JsonPropertyName("topic_id")]
    public required string TopicId { get; set; }

    [JsonPropertyName("topic_name")]
    public required string TopicName { get; set; }

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
