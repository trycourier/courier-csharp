using System.Text.Json.Serialization;

namespace Courier.Net;

public class InvalidListPatternRecipient
{
    [JsonPropertyName("user_id")]
    public string UserId { get; init; }

    [JsonPropertyName("list_id")]
    public string ListId { get; init; }
}
