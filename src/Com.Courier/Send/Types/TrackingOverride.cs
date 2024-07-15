using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record TrackingOverride
{
    [JsonPropertyName("open")]
    public required bool Open { get; init; }
}
