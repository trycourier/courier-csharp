using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record PutSubscriptionsRecipient
{
    [JsonPropertyName("recipientId")]
    public required string RecipientId { get; set; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
