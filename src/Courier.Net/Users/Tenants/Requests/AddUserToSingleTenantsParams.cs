using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net.Users;

public record AddUserToSingleTenantsParams
{
    [JsonPropertyName("profile")]
    public Dictionary<string, object>? Profile { get; init; }
}
