using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record RecipientPreferences
{
    [JsonPropertyName("categories")]
    public Dictionary<string, NotificationPreferenceDetails>? Categories { get; init; }

    [JsonPropertyName("notifications")]
    public Dictionary<string, NotificationPreferenceDetails>? Notifications { get; init; }
}
