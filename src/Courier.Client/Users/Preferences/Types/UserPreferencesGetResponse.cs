using System.Text.Json.Serialization;
using Courier.Client.Users;

#nullable enable

namespace Courier.Client.Users;

public record UserPreferencesGetResponse
{
    [JsonPropertyName("topic")]
    public required TopicPreference Topic { get; init; }
}
