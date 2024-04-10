using System.Text.Json.Serialization;

namespace Courier.Net;

public class BulkIngestError
{
    [JsonPropertyName("user")]
    public object User { get; init; }

    [JsonPropertyName("error")]
    public object Error { get; init; }
}
