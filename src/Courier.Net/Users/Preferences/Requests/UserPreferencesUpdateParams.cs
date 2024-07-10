using System.Text.Json.Serialization;
using Courier.Net.Users;

#nullable enable

namespace Courier.Net.Users;

public record UserPreferencesUpdateParams
{
    [JsonPropertyName("topic")]
    public required TopicPreferenceUpdate Topic { get; init; }
}
