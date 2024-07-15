using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record SubscribeUserToListRequest
{
    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
