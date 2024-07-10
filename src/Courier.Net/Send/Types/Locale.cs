using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record Locale
{
    [JsonPropertyName("content")]
    public required string Content { get; init; }
}
