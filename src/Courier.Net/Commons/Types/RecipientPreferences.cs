using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record RecipientPreferences
{
    [JsonPropertyName("categories")]
    public Dictionary<string, NotificationPreferenceDetails>? Categories { get; init; }

    [JsonPropertyName("notifications")]
    public Dictionary<string, NotificationPreferenceDetails>? Notifications { get; init; }
}
