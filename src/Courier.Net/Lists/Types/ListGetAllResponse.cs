using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class ListGetAllResponse
{
    [JsonPropertyName("paging")]
    public Paging Paging { get; init; }

    [JsonPropertyName("items")]
    public List<List> Items { get; init; }
}
