using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record BrandSettingsEmail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("templateOverride")]
    public BrandTemplateOverride? TemplateOverride { get; set; }

    [JsonPropertyName("head")]
    public EmailHead? Head { get; set; }

    [JsonPropertyName("footer")]
    public EmailFooter? Footer { get; set; }

    [JsonPropertyName("header")]
    public EmailHeader? Header { get; set; }

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
