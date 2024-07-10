using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record AirshipProfile
{
    [JsonPropertyName("audience")]
    public required AirshipProfileAudience Audience { get; init; }

    [JsonPropertyName("device_types")]
    public IEnumerable<object> DeviceTypes { get; init; } = new List<object>();
}
