using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record InvalidListRecipient
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; init; }

    [JsonPropertyName("list_pattern")]
    public required string ListPattern { get; init; }
}
