using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record WebhookProfile
{
    /// <summary>
    /// The URL to send the webhook request to.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    /// <summary>
    /// The HTTP method to use for the webhook request. Defaults to POST if not specified.
    /// </summary>
    [JsonPropertyName("method")]
    public WebhookMethod? Method { get; set; }

    /// <summary>
    /// Custom headers to include in the webhook request.
    /// </summary>
    [JsonPropertyName("headers")]
    public Dictionary<string, string>? Headers { get; set; }

    /// <summary>
    /// Authentication configuration for the webhook request.
    /// </summary>
    [JsonPropertyName("authentication")]
    public WebhookAuthentication? Authentication { get; set; }

    /// <summary>
    /// Specifies what profile information is included in the request payload. Defaults to 'limited' if not specified.
    /// </summary>
    [JsonPropertyName("profile")]
    public WebhookProfileType? Profile { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
