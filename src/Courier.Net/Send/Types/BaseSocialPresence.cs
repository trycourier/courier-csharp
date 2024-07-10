using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record BaseSocialPresence
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }
}
