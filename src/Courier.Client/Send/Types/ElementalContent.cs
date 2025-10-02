using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record ElementalContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// For example, "2022-01-01"
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; set; }

    [JsonPropertyName("brand")]
    public object? Brand { get; set; }

    [JsonPropertyName("elements")]
    public IEnumerable<ElementalNode> Elements { get; set; } = new List<ElementalNode>();

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
