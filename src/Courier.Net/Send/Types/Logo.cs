using System.Text.Json.Serialization;

namespace Courier.Net;

public class Logo
{
    [JsonPropertyName("href")]
    public string? Href { get; init; }

    [JsonPropertyName("image")]
    public string? Image { get; init; }
}
