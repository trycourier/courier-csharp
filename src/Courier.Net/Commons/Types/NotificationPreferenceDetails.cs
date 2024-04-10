using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class NotificationPreferenceDetails
{
    [JsonPropertyName("status")]
    public PreferenceStatus Status { get; init; }

    [JsonPropertyName("rules")]
    public List<Rule>? Rules { get; init; }

    [JsonPropertyName("channel_preferences")]
    public List<ChannelPreference>? ChannelPreferences { get; init; }
}
