using System.Text.Json.Serialization;

namespace Courier.Net;

public class IntercomRecipient
{
    [JsonPropertyName("id")]
    public string Id { get; init; }
}
