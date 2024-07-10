using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record ReplaceProfileResponse
{
    [JsonPropertyName("status")]
    public required string Status { get; init; }
}
