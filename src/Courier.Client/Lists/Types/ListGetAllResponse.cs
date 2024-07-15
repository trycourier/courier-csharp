using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record ListGetAllResponse
{
    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }

    [JsonPropertyName("items")]
    public IEnumerable<List> Items { get; init; } = new List<List>();
}
