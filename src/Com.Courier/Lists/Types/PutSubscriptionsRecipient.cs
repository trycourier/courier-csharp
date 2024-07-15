using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record PutSubscriptionsRecipient
{
    [JsonPropertyName("recipientId")]
    public required string RecipientId { get; init; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
