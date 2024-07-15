using System.Text.Json.Serialization;
using Com.Courier.Users;

#nullable enable

namespace Com.Courier.Users;

public record UserPreferencesUpdateParams
{
    [JsonPropertyName("topic")]
    public required TopicPreferenceUpdate Topic { get; init; }
}
