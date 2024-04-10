using System.Text.Json.Serialization;
using OneOf;
using Courier.Net;

namespace Courier.Net;

public class Automation
{
    [JsonPropertyName("cancelation_token")]
    public string? CancelationToken { get; init; }

    [JsonPropertyName("steps")]
    public List<OneOf<AutomationAddToDigestStep, AutomationAddToBatchStep, AutomationThrottleStep, AutomationCancelStep, AutomationDelayStep, AutomationFetchDataStep, AutomationInvokeStep, AutomationSendStep, AutomationV2SendStep, AutomationSendListStep, AutomationUpdateProfileStep>> Steps { get; init; }
}
