using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier.Users;

public record UserPreferencesUpdateResponse
{
    [JsonPropertyName("message")]
    public required string Message { get; init; }
}
