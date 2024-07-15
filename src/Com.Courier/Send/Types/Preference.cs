using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record Preference
{
    [JsonPropertyName("status")]
    public required PreferenceStatus Status { get; init; }

    [JsonPropertyName("rules")]
    public IEnumerable<Rule>? Rules { get; init; }

    [JsonPropertyName("channel_preferences")]
    public IEnumerable<ChannelPreference>? ChannelPreferences { get; init; }

    [JsonPropertyName("source")]
    public ChannelSource? Source { get; init; }
}
