using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record BulkGetJobUsersResponse
{
    [JsonPropertyName("items")]
    public IEnumerable<BulkMessageUserResponse> Items { get; init; } =
        new List<BulkMessageUserResponse>();

    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }
}
