using System.Text.Json.Serialization;

namespace Courier.Net;

public class Rule
{
    [JsonPropertyName("start")]
    public string? Start { get; init; }

    [JsonPropertyName("until")]
    public string Until { get; init; }
}
