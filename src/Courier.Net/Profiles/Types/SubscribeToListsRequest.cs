using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record SubscribeToListsRequest
{
    [JsonPropertyName("lists")]
    public IEnumerable<SubscribeToListsRequestListObject> Lists { get; init; } =
        new List<SubscribeToListsRequestListObject>();
}
