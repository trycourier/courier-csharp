using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record AutomationFetchDataStep : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("action")]
    public string Action { get; set; } = "fetch-data";

    [JsonPropertyName("webhook")]
    public required AutomationFetchDataWebhook Webhook { get; set; }

    [JsonPropertyName("merge_strategy")]
    public required MergeAlgorithm MergeStrategy { get; set; }

    [JsonPropertyName("idempotency_expiry")]
    public string? IdempotencyExpiry { get; set; }

    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    [JsonPropertyName("if")]
    public string? If { get; set; }

    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

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
