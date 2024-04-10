using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class BulkIngestUsersResponse
{
    [JsonPropertyName("total")]
    public int Total { get; init; }

    [JsonPropertyName("errors")]
    public List<BulkIngestError>? Errors { get; init; }
}
