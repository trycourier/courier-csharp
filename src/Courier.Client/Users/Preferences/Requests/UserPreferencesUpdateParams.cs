using System.Text.Json.Serialization;
using Courier.Client.Users;

#nullable enable

namespace Courier.Client.Users;

public record UserPreferencesUpdateParams
{
    [JsonPropertyName("topic")]
    public required TopicPreferenceUpdate Topic { get; init; }
}
