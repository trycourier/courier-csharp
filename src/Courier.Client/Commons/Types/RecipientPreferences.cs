using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record RecipientPreferences
{
    [JsonPropertyName("categories")]
    public Dictionary<string, NotificationPreferenceDetails>? Categories { get; set; }

    [JsonPropertyName("notifications")]
    public Dictionary<string, NotificationPreferenceDetails>? Notifications { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
