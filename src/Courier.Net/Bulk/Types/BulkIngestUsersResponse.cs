using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record BulkIngestUsersResponse
{
    [JsonPropertyName("total")]
    public required int Total { get; init; }

    [JsonPropertyName("errors")]
    public IEnumerable<BulkIngestError>? Errors { get; init; }
}
