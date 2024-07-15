using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record Logo
{
    [JsonPropertyName("href")]
    public string? Href { get; init; }

    [JsonPropertyName("image")]
    public string? Image { get; init; }
}
