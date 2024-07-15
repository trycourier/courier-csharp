using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record SubscribeToListsRequest
{
    [JsonPropertyName("lists")]
    public IEnumerable<SubscribeToListsRequestListObject> Lists { get; init; } =
        new List<SubscribeToListsRequestListObject>();
}
