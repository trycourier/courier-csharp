using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record SubscribeToListsRequest
{
    [JsonPropertyName("lists")]
    public IEnumerable<SubscribeToListsRequestListObject> Lists { get; set; } =
        new List<SubscribeToListsRequestListObject>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
