using System.Text.Json.Serialization;

namespace Courier.Net;

public class Conflict
{
    [JsonPropertyName("type")]
    public string Type { get; init; }

    /// <summary>
    /// A message describing the error that occurred.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; init; }
}
