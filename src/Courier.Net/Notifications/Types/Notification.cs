using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class Notification
{
    [JsonPropertyName("created_at")]
    public long CreatedAt { get; init; }

    [JsonPropertyName("id")]
    public string Id { get; init; }

    [JsonPropertyName("routing")]
    public MessageRouting Routing { get; init; }
}
