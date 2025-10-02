using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

namespace Courier.Client;

[Serializable]
public record AutomationAddToBatchStep : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("action")]
    public string Action { get; set; } = "add-to-batch";

    /// <summary>
    /// Defines the period of inactivity before the batch is released. Specified as an [ISO 8601 duration](https://en.wikipedia.org/wiki/ISO_8601#Durations)
    /// </summary>
    [JsonPropertyName("wait_period")]
    public required string WaitPeriod { get; set; }

    /// <summary>
    /// Defines the maximum wait time before the batch should be released. Must be less than wait period. Maximum of 60 days. Specified as an [ISO 8601 duration](https://en.wikipedia.org/wiki/ISO_8601#Durations)
    /// </summary>
    [JsonPropertyName("max_wait_period")]
    public required string MaxWaitPeriod { get; set; }

    /// <summary>
    /// If specified, the batch will release as soon as this number is reached
    /// </summary>
    [JsonPropertyName("max_items")]
    public OneOf<string, int>? MaxItems { get; set; }

    [JsonPropertyName("retain")]
    public required AutomationAddToBatchRetain Retain { get; set; }

    /// <summary>
    /// Determine the scope of the batching. If user, chosen in this order: recipient, profile.user_id, data.user_id, data.userId.
    /// If dynamic, then specify where the batch_key or a reference to the batch_key
    /// </summary>
    [JsonPropertyName("scope")]
    public AutomationAddToBatchScope? Scope { get; set; }

    /// <summary>
    /// If using scope=dynamic, provide the key or a reference (e.g., refs.data.batch_key)
    /// </summary>
    [JsonPropertyName("batch_key")]
    public string? BatchKey { get; set; }

    [JsonPropertyName("batch_id")]
    public string? BatchId { get; set; }

    /// <summary>
    /// Defines the field of the data object the batch is set to when complete. Defaults to `batch`
    /// </summary>
    [JsonPropertyName("category_key")]
    public string? CategoryKey { get; set; }

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
