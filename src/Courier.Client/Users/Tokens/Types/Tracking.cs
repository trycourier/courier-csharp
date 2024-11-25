using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

public record Tracking
{
    /// <summary>
    /// The operating system version
    /// </summary>
    [JsonPropertyName("os_version")]
    public string? OsVersion { get; set; }

    /// <summary>
    /// The IP address of the device
    /// </summary>
    [JsonPropertyName("ip")]
    public string? Ip { get; set; }

    /// <summary>
    /// The latitude of the device
    /// </summary>
    [JsonPropertyName("lat")]
    public string? Lat { get; set; }

    /// <summary>
    /// The longitude of the device
    /// </summary>
    [JsonPropertyName("long")]
    public string? Long { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
