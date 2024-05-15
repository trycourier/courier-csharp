using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class AutomationThrottleStep
{
    [JsonPropertyName("action")]
    public string Action { get; init; }

    /// <summary>
    /// Maximum number of allowed notifications in that timeframe
    /// </summary>
    [JsonPropertyName("max_allowed")]
    public int MaxAllowed { get; init; }

    /// <summary>
    /// Defines the throttle period which corresponds to the max_allowed. Specified as an ISO 8601 duration, https://en.wikipedia.org/wiki/ISO_8601#Durations
    /// </summary>
    [JsonPropertyName("period")]
    public string Period { get; init; }

    [JsonPropertyName("scope")]
    public AutomationThrottleScope Scope { get; init; }

    /// <summary>
    /// If using scope=dynamic, provide the reference (e.g., refs.data.throttle_key) to the how the throttle should be identified
    /// </summary>
    [JsonPropertyName("throttle_key")]
    public string? ThrottleKey { get; init; }

    /// <summary>
    /// Value must be true
    /// </summary>
    [JsonPropertyName("should_alert")]
    public bool ShouldAlert { get; init; }

    [JsonPropertyName("on_throttle")]
    public AutomationThrottleOnThrottle OnThrottle { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
