using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

namespace Courier.Client;

[Serializable]
public record Automation : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("cancelation_token")]
    public string? CancelationToken { get; set; }

    [JsonPropertyName("steps")]
    public IEnumerable<
        OneOf<
            AutomationAddToDigestStep,
            AutomationAddToBatchStep,
            AutomationThrottleStep,
            AutomationCancelStep,
            AutomationDelayStep,
            AutomationFetchDataStep,
            AutomationInvokeStep,
            AutomationSendStep,
            AutomationV2SendStep,
            AutomationSendListStep,
            AutomationUpdateProfileStep
        >
    > Steps { get; set; } =
        new List<
            OneOf<
                AutomationAddToDigestStep,
                AutomationAddToBatchStep,
                AutomationThrottleStep,
                AutomationCancelStep,
                AutomationDelayStep,
                AutomationFetchDataStep,
                AutomationInvokeStep,
                AutomationSendStep,
                AutomationV2SendStep,
                AutomationSendListStep,
                AutomationUpdateProfileStep
            >
        >();

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
