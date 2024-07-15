using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record ProfileGetParameters
{
    [JsonPropertyName("recipientId")]
    public required string RecipientId { get; init; }
}
