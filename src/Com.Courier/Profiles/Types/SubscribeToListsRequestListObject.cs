using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record SubscribeToListsRequestListObject
{
    [JsonPropertyName("listId")]
    public required string ListId { get; init; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
