using System.Text.Json.Serialization;

namespace Courier.Net;

public class Delay
{
    /// <summary>
    /// The duration of the delay in milliseconds.
    /// </summary>
    [JsonPropertyName("duration")]
    public int Duration { get; init; }
}
