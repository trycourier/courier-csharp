using System.Text.Json.Serialization;

namespace Courier.Net;

public class SendToSlackUserId
{
    [JsonPropertyName("user_id")]
    public string UserId { get; init; }

    [JsonPropertyName("access_token")]
    public string AccessToken { get; init; }
}
