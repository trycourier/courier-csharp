using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record SubscribeToListsResponse
{
    [JsonPropertyName("status")]
    public required string Status { get; init; }
}
