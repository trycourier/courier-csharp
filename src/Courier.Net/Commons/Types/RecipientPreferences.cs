using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class RecipientPreferences
{
    [JsonPropertyName("categories")]
    public Dictionary<string, NotificationPreferenceDetails>? Categories { get; init; }

    [JsonPropertyName("notifications")]
    public Dictionary<string, NotificationPreferenceDetails>? Notifications { get; init; }
}
