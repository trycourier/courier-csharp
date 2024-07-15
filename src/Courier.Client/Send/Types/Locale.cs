using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record Locale
{
    [JsonPropertyName("content")]
    public required string Content { get; init; }
}
