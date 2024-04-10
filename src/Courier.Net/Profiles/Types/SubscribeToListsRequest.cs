using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class SubscribeToListsRequest
{
    [JsonPropertyName("lists")]
    public List<SubscribeToListsRequestListObject> Lists { get; init; }
}
