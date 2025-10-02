using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record SubscribeUserToListRequest
{
    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
