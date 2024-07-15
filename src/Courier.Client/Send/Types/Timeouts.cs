using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record Timeouts
{
    [JsonPropertyName("provider")]
    public int? Provider { get; init; }

    [JsonPropertyName("channel")]
    public int? Channel { get; init; }
}
