using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record ProfileGetParameters
{
    [JsonPropertyName("recipientId")]
    public required string RecipientId { get; init; }
}
