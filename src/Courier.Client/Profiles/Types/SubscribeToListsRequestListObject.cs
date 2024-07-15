using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record SubscribeToListsRequestListObject
{
    [JsonPropertyName("listId")]
    public required string ListId { get; init; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
