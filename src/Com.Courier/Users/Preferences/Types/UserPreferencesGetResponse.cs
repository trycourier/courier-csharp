using System.Text.Json.Serialization;
using Com.Courier.Users;

#nullable enable

namespace Com.Courier.Users;

public record UserPreferencesGetResponse
{
    [JsonPropertyName("topic")]
    public required TopicPreference Topic { get; init; }
}
