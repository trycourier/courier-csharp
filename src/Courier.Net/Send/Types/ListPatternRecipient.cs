using System.Text.Json.Serialization;

namespace Courier.Net;

public class ListPatternRecipient
{
    [JsonPropertyName("list_pattern")]
    public string? ListPattern { get; init; }

    [JsonPropertyName("data")]
    public Dictionary<string, object>? Data { get; init; }
}
