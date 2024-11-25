using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

public record Device
{
    /// <summary>
    /// Id of the application the token is used for
    /// </summary>
    [JsonPropertyName("app_id")]
    public string? AppId { get; set; }

    /// <summary>
    /// Id of the advertising identifier
    /// </summary>
    [JsonPropertyName("ad_id")]
    public string? AdId { get; set; }

    /// <summary>
    /// Id of the device the token is associated with
    /// </summary>
    [JsonPropertyName("device_id")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// The device platform i.e. android, ios, web
    /// </summary>
    [JsonPropertyName("platform")]
    public string? Platform { get; set; }

    /// <summary>
    /// The device manufacturer
    /// </summary>
    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    /// <summary>
    /// The device model
    /// </summary>
    [JsonPropertyName("model")]
    public string? Model { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
