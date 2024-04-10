using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class ListRecipient
{
    [JsonPropertyName("list_id")]
    public string? ListId { get; init; }

    [JsonPropertyName("data")]
    public Dictionary<string, object>? Data { get; init; }

    [JsonPropertyName("filters")]
    public List<ListFilter>? Filters { get; init; }
}
