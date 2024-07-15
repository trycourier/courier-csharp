using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record MergeProfileResponse
{
    [JsonPropertyName("status")]
    public required string Status { get; init; }
}
