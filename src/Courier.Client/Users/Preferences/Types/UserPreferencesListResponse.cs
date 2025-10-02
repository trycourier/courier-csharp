using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

namespace Courier.Client.Users;

[Serializable]
public record UserPreferencesListResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Deprecated - Paging not implemented on this endpoint
    /// </summary>
    [JsonPropertyName("paging")]
    public required Paging Paging { get; set; }

    /// <summary>
    /// The Preferences associated with the user_id.
    /// </summary>
    [JsonPropertyName("items")]
    public IEnumerable<TopicPreference> Items { get; set; } = new List<TopicPreference>();

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
