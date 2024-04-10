using System.Text.Json.Serialization;

namespace Courier.Net;

public class InvalidListRecipient
{
    [JsonPropertyName("user_id")]
    public string UserId { get; init; }

    [JsonPropertyName("list_pattern")]
    public string ListPattern { get; init; }
}
