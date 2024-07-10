using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record BulkIngestError
{
    [JsonPropertyName("user")]
    public required object User { get; init; }

    [JsonPropertyName("error")]
    public required object Error { get; init; }
}
