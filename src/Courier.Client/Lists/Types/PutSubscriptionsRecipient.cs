using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record PutSubscriptionsRecipient
{
    [JsonPropertyName("recipientId")]
    public required string RecipientId { get; init; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
