using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record ReplaceProfileResponse
{
    [JsonPropertyName("status")]
    public required string Status { get; init; }
}
