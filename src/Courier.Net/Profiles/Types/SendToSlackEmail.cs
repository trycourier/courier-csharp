using System.Text.Json.Serialization;

namespace Courier.Net;

public class SendToSlackEmail
{
    [JsonPropertyName("email")]
    public string Email { get; init; }

    [JsonPropertyName("access_token")]
    public string AccessToken { get; init; }
}
