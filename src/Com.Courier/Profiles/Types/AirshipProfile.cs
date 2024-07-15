using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record AirshipProfile
{
    [JsonPropertyName("audience")]
    public required AirshipProfileAudience Audience { get; init; }

    [JsonPropertyName("device_types")]
    public IEnumerable<object> DeviceTypes { get; init; } = new List<object>();
}
