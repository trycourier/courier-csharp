using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ListRecipient
{
    [JsonPropertyName("list_id")]
    public string? ListId { get; set; }

    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

    [JsonPropertyName("filters")]
    public IEnumerable<ListFilter>? Filters { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
