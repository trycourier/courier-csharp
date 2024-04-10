using System.Text.Json.Serialization;

namespace Courier.Net;

public class TrackingOverride
{
    [JsonPropertyName("open")]
    public bool Open { get; init; }
}
