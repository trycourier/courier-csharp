using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record InvalidUserRecipient
{
    [JsonPropertyName("list_id")]
    public required string ListId { get; init; }

    [JsonPropertyName("list_pattern")]
    public required string ListPattern { get; init; }
}
