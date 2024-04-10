using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class ListSubscriptionRecipient
{
    [JsonPropertyName("recipientId")]
    public string RecipientId { get; init; }

    [JsonPropertyName("created")]
    public string? Created { get; init; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
