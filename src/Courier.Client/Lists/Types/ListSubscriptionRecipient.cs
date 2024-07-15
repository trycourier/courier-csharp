using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record ListSubscriptionRecipient
{
    [JsonPropertyName("recipientId")]
    public required string RecipientId { get; init; }

    [JsonPropertyName("created")]
    public string? Created { get; init; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
