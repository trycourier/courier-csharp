using System.Text.Json.Serialization;

namespace Courier.Net;

public class InvalidUserRecipient
{
    [JsonPropertyName("list_id")]
    public string ListId { get; init; }

    [JsonPropertyName("list_pattern")]
    public string ListPattern { get; init; }
}
