using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net.Users;

public record UserPreferencesUpdateResponse
{
    [JsonPropertyName("message")]
    public required string Message { get; init; }
}
