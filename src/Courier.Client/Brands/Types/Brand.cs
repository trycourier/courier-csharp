using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record Brand : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The date/time of when the brand was created. Represented in milliseconds since Unix epoch.
    /// </summary>
    [JsonPropertyName("created")]
    public required int Created { get; set; }

    /// <summary>
    /// Brand Identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Brand name
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The date/time of when the brand was published. Represented in milliseconds since Unix epoch.
    /// </summary>
    [JsonPropertyName("published")]
    public required int Published { get; set; }

    [JsonPropertyName("settings")]
    public required BrandSettings Settings { get; set; }

    /// <summary>
    /// The date/time of when the brand was updated. Represented in milliseconds since Unix epoch.
    /// </summary>
    [JsonPropertyName("updated")]
    public required int Updated { get; set; }

    [JsonPropertyName("snippets")]
    public BrandSnippets? Snippets { get; set; }

    /// <summary>
    /// The version identifier for the brand
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; set; }

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
