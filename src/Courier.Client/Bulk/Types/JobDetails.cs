using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record JobDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("definition")]
    public required InboundBulkMessage Definition { get; set; }

    [JsonPropertyName("enqueued")]
    public required int Enqueued { get; set; }

    [JsonPropertyName("failures")]
    public required int Failures { get; set; }

    [JsonPropertyName("received")]
    public required int Received { get; set; }

    [JsonPropertyName("status")]
    public required BulkJobStatus Status { get; set; }

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
