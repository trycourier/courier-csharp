using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record SubscribeUserToListRequest
{
    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
