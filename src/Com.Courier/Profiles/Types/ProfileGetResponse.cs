using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record ProfileGetResponse
{
    [JsonPropertyName("profile")]
    public Dictionary<string, object> Profile { get; init; } = new Dictionary<string, object>();

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
