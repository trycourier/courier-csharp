using System.Text.Json.Serialization;

namespace Courier.Net;

public class SendDirectMessage
{
    [JsonPropertyName("user_id")]
    public string UserId { get; init; }
}
