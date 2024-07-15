using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record BulkGetJobUsersResponse
{
    [JsonPropertyName("items")]
    public IEnumerable<BulkMessageUserResponse> Items { get; init; } =
        new List<BulkMessageUserResponse>();

    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }
}
