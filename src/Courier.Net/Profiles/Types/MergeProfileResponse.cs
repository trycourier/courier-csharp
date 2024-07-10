using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record MergeProfileResponse
{
    [JsonPropertyName("status")]
    public required string Status { get; init; }
}
