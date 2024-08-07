using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record Delay
{
    /// <summary>
    /// The duration of the delay in milliseconds.
    /// </summary>
    [JsonPropertyName("duration")]
    public required int Duration { get; init; }
}
