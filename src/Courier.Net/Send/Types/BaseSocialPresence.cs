using System.Text.Json.Serialization;

namespace Courier.Net;

public class BaseSocialPresence
{
    [JsonPropertyName("url")]
    public string Url { get; init; }
}
