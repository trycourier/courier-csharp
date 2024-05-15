using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class PutSubscriptionsRecipient
{
    [JsonPropertyName("recipientId")]
    public string RecipientId { get; init; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
