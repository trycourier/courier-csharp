using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record InvalidListPatternRecipient
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; init; }

    [JsonPropertyName("list_id")]
    public required string ListId { get; init; }
}
