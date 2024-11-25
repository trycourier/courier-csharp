using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AutomationThrottleStep
{
    [JsonPropertyName("action")]
    public required string Action { get; set; }

    /// <summary>
    /// Maximum number of allowed notifications in that timeframe
    /// </summary>
    [JsonPropertyName("max_allowed")]
    public required int MaxAllowed { get; set; }

    /// <summary>
    /// Defines the throttle period which corresponds to the max_allowed. Specified as an ISO 8601 duration, https://en.wikipedia.org/wiki/ISO_8601#Durations
    /// </summary>
    [JsonPropertyName("period")]
    public required string Period { get; set; }

    [JsonPropertyName("scope")]
    public required AutomationThrottleScope Scope { get; set; }

    /// <summary>
    /// If using scope=dynamic, provide the reference (e.g., refs.data.throttle_key) to the how the throttle should be identified
    /// </summary>
    [JsonPropertyName("throttle_key")]
    public string? ThrottleKey { get; set; }

    /// <summary>
    /// Value must be true
    /// </summary>
    [JsonPropertyName("should_alert")]
    public required bool ShouldAlert { get; set; }

    [JsonPropertyName("on_throttle")]
    public required AutomationThrottleOnThrottle OnThrottle { get; set; }

    [JsonPropertyName("if")]
    public string? If { get; set; }

    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
