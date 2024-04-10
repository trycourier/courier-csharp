using System.Text.Json.Serialization;

namespace Courier.Net.Users;

public class Device
{
    /// <summary>
    /// Id of the application the token is used for
    /// </summary>
    [JsonPropertyName("app_id")]
    public string? AppId { get; init; }

    /// <summary>
    /// Id of the advertising identifier
    /// </summary>
    [JsonPropertyName("ad_id")]
    public string? AdId { get; init; }

    /// <summary>
    /// Id of the device the token is associated with
    /// </summary>
    [JsonPropertyName("device_id")]
    public string? DeviceId { get; init; }

    /// <summary>
    /// The device platform i.e. android, ios, web
    /// </summary>
    [JsonPropertyName("platform")]
    public string? Platform { get; init; }

    /// <summary>
    /// The device manufacturer
    /// </summary>
    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; init; }

    /// <summary>
    /// The device model
    /// </summary>
    [JsonPropertyName("model")]
    public string? Model { get; init; }
}
