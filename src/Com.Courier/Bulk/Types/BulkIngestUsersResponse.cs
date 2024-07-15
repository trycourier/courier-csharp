using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record BulkIngestUsersResponse
{
    [JsonPropertyName("total")]
    public required int Total { get; init; }

    [JsonPropertyName("errors")]
    public IEnumerable<BulkIngestError>? Errors { get; init; }
}
