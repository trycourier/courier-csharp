using System.Text.Json.Serialization;
using Courier.Net.Users;

#nullable enable

namespace Courier.Net.Users;

public record UserPreferencesGetResponse
{
    [JsonPropertyName("topic")]
    public required TopicPreference Topic { get; init; }
}
