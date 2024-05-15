using System.Text.Json.Serialization;

namespace Courier.Net;

public class SendToSlackChannel
{
    [JsonPropertyName("channel")]
    public string Channel { get; init; }

    [JsonPropertyName("access_token")]
    public string AccessToken { get; init; }
}
