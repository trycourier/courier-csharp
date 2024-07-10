using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record ProfileGetResponse
{
    [JsonPropertyName("profile")]
    public Dictionary<string, object> Profile { get; init; } = new Dictionary<string, object>();

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
