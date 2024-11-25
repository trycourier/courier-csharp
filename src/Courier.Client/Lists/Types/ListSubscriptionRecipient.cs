using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ListSubscriptionRecipient
{
    [JsonPropertyName("recipientId")]
    public required string RecipientId { get; set; }

    [JsonPropertyName("created")]
    public string? Created { get; set; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
