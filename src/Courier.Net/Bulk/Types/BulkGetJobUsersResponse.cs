using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class BulkGetJobUsersResponse
{
    [JsonPropertyName("items")]
    public List<BulkMessageUserResponse> Items { get; init; }

    [JsonPropertyName("paging")]
    public Paging Paging { get; init; }
}
