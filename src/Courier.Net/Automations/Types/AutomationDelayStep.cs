using System.Text.Json.Serialization;

namespace Courier.Net;

public class AutomationDelayStep
{
    [JsonPropertyName("action")]
    public string Action { get; init; }

    /// <summary>
    /// The [ISO 8601 duration](https://en.wikipedia.org/wiki/ISO_8601#Durations) string for how long to delay for
    /// </summary>
    [JsonPropertyName("duration")]
    public string? Duration { get; init; }

    /// <summary>
    /// The ISO 8601 timestamp for when the delay should end
    /// </summary>
    [JsonPropertyName("until")]
    public string? Until { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
