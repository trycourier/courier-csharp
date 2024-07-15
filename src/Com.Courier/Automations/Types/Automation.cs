using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;
using OneOf;

#nullable enable

namespace Com.Courier;

public record Automation
{
    [JsonPropertyName("cancelation_token")]
    public string? CancelationToken { get; init; }

    [JsonPropertyName("steps")]
    [JsonConverter(
        typeof(CollectionItemSerializer<
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
            >,
            OneOfSerializer<
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
            >
        >)
    )]
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
    > Steps { get; init; } =
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
}
