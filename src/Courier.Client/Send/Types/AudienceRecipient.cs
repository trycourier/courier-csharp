using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record AudienceRecipient : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique identifier associated with an Audience. A message will be sent to each user in the audience.
    /// </summary>
    [JsonPropertyName("audience_id")]
    public required string AudienceId { get; set; }

    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

    [JsonPropertyName("filters")]
    public IEnumerable<AudienceFilter>? Filters { get; set; }

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
