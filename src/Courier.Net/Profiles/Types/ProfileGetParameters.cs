using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record ProfileGetParameters
{
    [JsonPropertyName("recipientId")]
    public required string RecipientId { get; init; }
}
