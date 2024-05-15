using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class ProfileGetResponse
{
    [JsonPropertyName("profile")]
    public Dictionary<string, object> Profile { get; init; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
