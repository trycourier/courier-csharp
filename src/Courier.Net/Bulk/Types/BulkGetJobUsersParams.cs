using System.Text.Json.Serialization;

namespace Courier.Net;

public class BulkGetJobUsersParams
{
    [JsonPropertyName("jobId")]
    public string JobId { get; init; }

    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }
}
