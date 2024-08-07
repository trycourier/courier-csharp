using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record ListPatternRecipient
{
    [JsonPropertyName("list_pattern")]
    public string? ListPattern { get; init; }

    [JsonPropertyName("data")]
    public Dictionary<string, object>? Data { get; init; }
}
