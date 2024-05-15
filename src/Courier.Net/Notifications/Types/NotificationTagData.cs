using System.Text.Json.Serialization;

namespace Courier.Net;

public class NotificationTagData
{
    [JsonPropertyName("id")]
    public string Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }
}
