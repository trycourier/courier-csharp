using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record ListSubscriptionRecipient
{
    [JsonPropertyName("recipientId")]
    public required string RecipientId { get; init; }

    [JsonPropertyName("created")]
    public string? Created { get; init; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
