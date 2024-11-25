using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record NotificationPreferenceDetails
{
    [JsonPropertyName("status")]
    public required PreferenceStatus Status { get; set; }

    [JsonPropertyName("rules")]
    public IEnumerable<Rule>? Rules { get; set; }

    [JsonPropertyName("channel_preferences")]
    public IEnumerable<ChannelPreference>? ChannelPreferences { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
