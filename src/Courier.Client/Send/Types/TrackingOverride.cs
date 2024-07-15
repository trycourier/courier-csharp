using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record TrackingOverride
{
    [JsonPropertyName("open")]
    public required bool Open { get; init; }
}
