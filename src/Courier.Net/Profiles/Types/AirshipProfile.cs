using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class AirshipProfile
{
    [JsonPropertyName("audience")]
    public AirshipProfileAudience Audience { get; init; }

    [JsonPropertyName("device_types")]
    public List<object> DeviceTypes { get; init; }
}
