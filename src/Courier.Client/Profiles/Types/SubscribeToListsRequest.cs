using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record SubscribeToListsRequest
{
    [JsonPropertyName("lists")]
    public IEnumerable<SubscribeToListsRequestListObject> Lists { get; init; } =
        new List<SubscribeToListsRequestListObject>();
}
