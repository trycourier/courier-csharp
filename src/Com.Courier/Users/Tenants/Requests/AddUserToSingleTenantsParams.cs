using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier.Users;

public record AddUserToSingleTenantsParams
{
    [JsonPropertyName("profile")]
    public Dictionary<string, object>? Profile { get; init; }
}
