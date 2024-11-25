using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record InboundBulkMessageUser
{
    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; set; }

    [JsonPropertyName("profile")]
    public object? Profile { get; set; }

    [JsonPropertyName("recipient")]
    public string? Recipient { get; set; }

    [JsonPropertyName("data")]
    public object? Data { get; set; }

    [JsonPropertyName("to")]
    public UserRecipient? To { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
