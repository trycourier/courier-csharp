using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

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
