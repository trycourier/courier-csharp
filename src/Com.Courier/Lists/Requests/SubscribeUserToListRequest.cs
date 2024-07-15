using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record SubscribeUserToListRequest
{
    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
