using System.Text.Json.Serialization;

namespace Courier.Net;

public class Locale
{
    [JsonPropertyName("content")]
    public string Content { get; init; }
}
