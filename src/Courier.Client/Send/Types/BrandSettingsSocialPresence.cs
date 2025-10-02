using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record BrandSettingsSocialPresence : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("inheritDefault")]
    public bool? InheritDefault { get; set; }

    [JsonPropertyName("facebook")]
    public BaseSocialPresence? Facebook { get; set; }

    [JsonPropertyName("instagram")]
    public BaseSocialPresence? Instagram { get; set; }

    [JsonPropertyName("linkedin")]
    public BaseSocialPresence? Linkedin { get; set; }

    [JsonPropertyName("medium")]
    public BaseSocialPresence? Medium { get; set; }

    [JsonPropertyName("twitter")]
    public BaseSocialPresence? Twitter { get; set; }

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
