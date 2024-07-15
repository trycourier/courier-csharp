using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record InboundBulkMessageUser
{
    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }

    [JsonPropertyName("profile")]
    public object? Profile { get; init; }

    [JsonPropertyName("recipient")]
    public string? Recipient { get; init; }

    [JsonPropertyName("data")]
    public object? Data { get; init; }

    [JsonPropertyName("to")]
    public UserRecipient? To { get; init; }
}
