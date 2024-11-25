using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ProfileGetResponse
{
    [JsonPropertyName("profile")]
    public Dictionary<string, object?> Profile { get; set; } = new Dictionary<string, object?>();

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
