using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class BulkMessageUserResponse
{
    [JsonPropertyName("status")]
    public BulkJobUserStatus Status { get; init; }

    [JsonPropertyName("messageId")]
    public string? MessageId { get; init; }

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
