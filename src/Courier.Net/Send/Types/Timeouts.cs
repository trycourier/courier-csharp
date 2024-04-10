using System.Text.Json.Serialization;

namespace Courier.Net;

public class Timeouts
{
    [JsonPropertyName("provider")]
    public int? Provider { get; init; }

    [JsonPropertyName("channel")]
    public int? Channel { get; init; }
}
