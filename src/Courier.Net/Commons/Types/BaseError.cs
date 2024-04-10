using System.Text.Json.Serialization;

namespace Courier.Net;

public class BaseError
{
    /// <summary>
    /// A message describing the error that occurred.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; init; }
}
