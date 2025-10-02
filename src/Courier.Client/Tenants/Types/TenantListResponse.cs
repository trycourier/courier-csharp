using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record TenantListResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A pointer to the next page of results. Defined only when has_more is set to true.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Set to true when there are more pages that can be retrieved.
    /// </summary>
    [JsonPropertyName("has_more")]
    public required bool HasMore { get; set; }

    /// <summary>
    /// An array of Tenants
    /// </summary>
    [JsonPropertyName("items")]
    public IEnumerable<Tenant> Items { get; set; } = new List<Tenant>();

    /// <summary>
    /// A url that may be used to generate fetch the next set of results.
    /// Defined only when has_more is set to true
    /// </summary>
    [JsonPropertyName("next_url")]
    public string? NextUrl { get; set; }

    /// <summary>
    /// A url that may be used to generate these results.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    /// <summary>
    /// Always set to "list". Represents the type of this object.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = "list";

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
