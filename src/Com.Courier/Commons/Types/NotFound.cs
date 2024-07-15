using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record NotFound
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>
    /// A message describing the error that occurred.
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; init; }
}
