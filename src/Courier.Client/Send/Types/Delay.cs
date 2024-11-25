using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record Delay
{
    /// <summary>
    /// The duration of the delay in milliseconds.
    /// </summary>
    [JsonPropertyName("duration")]
    public int? Duration { get; set; }

    /// <summary>
    /// An ISO 8601 timestamp that specifies when it should be delivered or an OpenStreetMap opening_hours-like format that specifies the [Delivery Window](https://www.courier.com/docs/platform/sending/failover/#delivery-window) (e.g., 'Mo-Fr 08:00-18:00pm')
    /// </summary>
    [JsonPropertyName("until")]
    public string? Until { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
