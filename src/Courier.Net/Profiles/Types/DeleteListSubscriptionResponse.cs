using System.Text.Json.Serialization;

namespace Courier.Net;

public class DeleteListSubscriptionResponse
{
    [JsonPropertyName("status")]
    public string Status { get; init; }
}
