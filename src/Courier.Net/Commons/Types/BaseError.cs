using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record BaseError
{
    /// <summary>
    /// A message describing the error that occurred.
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; init; }
}
