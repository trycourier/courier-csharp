using System.Text.Json.Serialization;

namespace Courier.Net;

public class SubscribeToListsResponse
{
    [JsonPropertyName("status")]
    public string Status { get; init; }
}
