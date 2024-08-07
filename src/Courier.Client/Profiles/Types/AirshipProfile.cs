using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record AirshipProfile
{
    [JsonPropertyName("audience")]
    public required AirshipProfileAudience Audience { get; init; }

    [JsonPropertyName("device_types")]
    public IEnumerable<object> DeviceTypes { get; init; } = new List<object>();
}
