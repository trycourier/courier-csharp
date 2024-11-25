using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AirshipProfile
{
    [JsonPropertyName("audience")]
    public required AirshipProfileAudience Audience { get; set; }

    [JsonPropertyName("device_types")]
    public IEnumerable<object> DeviceTypes { get; set; } = new List<object>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
