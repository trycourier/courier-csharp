using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record AutomationThrottleStep : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("action")]
    public string Action { get; set; } = "throttle";

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
    public bool ShouldAlert { get; set; } = false;

    [JsonPropertyName("on_throttle")]
    public required AutomationThrottleOnThrottle OnThrottle { get; set; }

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
