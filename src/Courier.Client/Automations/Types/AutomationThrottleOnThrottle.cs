using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record AutomationThrottleOnThrottle : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The node to go to if the request is throttled
    /// </summary>
    [JsonPropertyName("$node_id")]
    public required string NodeId { get; set; }

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
