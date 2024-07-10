using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record TrackingOverride
{
    [JsonPropertyName("open")]
    public required bool Open { get; init; }
}
