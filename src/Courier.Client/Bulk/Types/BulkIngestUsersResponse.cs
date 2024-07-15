using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record BulkIngestUsersResponse
{
    [JsonPropertyName("total")]
    public required int Total { get; init; }

    [JsonPropertyName("errors")]
    public IEnumerable<BulkIngestError>? Errors { get; init; }
}
