using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record WebhookAuthentication
{
    /// <summary>
    /// The authentication mode to use. Defaults to 'none' if not specified.
    /// </summary>
    [JsonPropertyName("mode")]
    public required WebhookAuthMode Mode { get; set; }

    /// <summary>
    /// Username for basic authentication.
    /// </summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>
    /// Password for basic authentication.
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>
    /// Token for bearer authentication.
    /// </summary>
    [JsonPropertyName("token")]
    public string? Token { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
