using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record EmailHead
{
    [JsonPropertyName("inheritDefault")]
    public required bool InheritDefault { get; init; }

    [JsonPropertyName("content")]
    public string? Content { get; init; }
}
