using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record ProfileGetResponse
{
    [JsonPropertyName("profile")]
    public Dictionary<string, object> Profile { get; init; } = new Dictionary<string, object>();

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
