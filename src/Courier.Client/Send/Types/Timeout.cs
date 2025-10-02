using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record Timeout : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("provider")]
    public Dictionary<string, int>? Provider { get; set; }

    [JsonPropertyName("channel")]
    public Dictionary<string, int>? Channel { get; set; }

    [JsonPropertyName("message")]
    public int? Message { get; set; }

    [JsonPropertyName("escalation")]
    public int? Escalation { get; set; }

    [JsonPropertyName("criteria")]
    public Criteria? Criteria { get; set; }

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
