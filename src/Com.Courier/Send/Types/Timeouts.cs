using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record Timeouts
{
    [JsonPropertyName("provider")]
    public int? Provider { get; init; }

    [JsonPropertyName("channel")]
    public int? Channel { get; init; }
}
