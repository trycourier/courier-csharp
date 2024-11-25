using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record SubscribeToListsRequestListObject
{
    [JsonPropertyName("listId")]
    public required string ListId { get; set; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
