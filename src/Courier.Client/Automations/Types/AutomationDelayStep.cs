using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AutomationDelayStep
{
    [JsonPropertyName("action")]
    public required string Action { get; set; }

    /// <summary>
    /// The [ISO 8601 duration](https://en.wikipedia.org/wiki/ISO_8601#Durations) string for how long to delay for
    /// </summary>
    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    /// <summary>
    /// The ISO 8601 timestamp for when the delay should end
    /// </summary>
    [JsonPropertyName("until")]
    public string? Until { get; set; }

    [JsonPropertyName("if")]
    public string? If { get; set; }

    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
