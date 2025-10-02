using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record RoutingStrategy : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The method for selecting channels to send the message with. Value can be either 'single' or 'all'. If not provided will default to 'single'
    /// </summary>
    [JsonPropertyName("method")]
    public required RoutingStrategyMethod Method { get; set; }

    /// <summary>
    /// An array of valid channel identifiers (like email, push, sms, etc.) and additional routing nodes.
    /// </summary>
    [JsonPropertyName("channels")]
    public IEnumerable<string> Channels { get; set; } = new List<string>();

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
