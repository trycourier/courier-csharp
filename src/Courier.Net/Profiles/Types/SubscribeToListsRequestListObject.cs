using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class SubscribeToListsRequestListObject
{
    [JsonPropertyName("listId")]
    public string ListId { get; init; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
