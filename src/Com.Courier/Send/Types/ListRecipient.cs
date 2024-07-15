using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record ListRecipient
{
    [JsonPropertyName("list_id")]
    public string? ListId { get; init; }

    [JsonPropertyName("data")]
    public Dictionary<string, object>? Data { get; init; }

    [JsonPropertyName("filters")]
    public IEnumerable<ListFilter>? Filters { get; init; }
}
