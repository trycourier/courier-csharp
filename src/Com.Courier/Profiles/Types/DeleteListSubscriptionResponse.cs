using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record DeleteListSubscriptionResponse
{
    [JsonPropertyName("status")]
    public required string Status { get; init; }
}
