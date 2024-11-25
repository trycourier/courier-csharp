using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ListGetAllResponse
{
    [JsonPropertyName("paging")]
    public required Paging Paging { get; set; }

    [JsonPropertyName("items")]
    public IEnumerable<List> Items { get; set; } = new List<List>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
