using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier.Users;

public record Tracking
{
    /// <summary>
    /// The operating system version
    /// </summary>
    [JsonPropertyName("os_version")]
    public string? OsVersion { get; init; }

    /// <summary>
    /// The IP address of the device
    /// </summary>
    [JsonPropertyName("ip")]
    public string? Ip { get; init; }

    /// <summary>
    /// The latitude of the device
    /// </summary>
    [JsonPropertyName("lat")]
    public string? Lat { get; init; }

    /// <summary>
    /// The longitude of the device
    /// </summary>
    [JsonPropertyName("long")]
    public string? Long { get; init; }
}
