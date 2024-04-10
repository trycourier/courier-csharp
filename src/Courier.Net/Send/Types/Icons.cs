using System.Text.Json.Serialization;

namespace Courier.Net;

public class Icons
{
    [JsonPropertyName("bell")]
    public string? Bell { get; init; }

    [JsonPropertyName("message")]
    public string? Message { get; init; }
}
