using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record Automation
{
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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
