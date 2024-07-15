using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record RecipientPreferences
{
    [JsonPropertyName("categories")]
    public Dictionary<string, NotificationPreferenceDetails>? Categories { get; init; }

    [JsonPropertyName("notifications")]
    public Dictionary<string, NotificationPreferenceDetails>? Notifications { get; init; }
}
