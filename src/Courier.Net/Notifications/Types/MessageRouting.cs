using System.Text.Json.Serialization;
using Courier.Net;
using OneOf;

namespace Courier.Net;

public class MessageRouting
{
    [JsonPropertyName("method")]
    public MessageRoutingMethod Method { get; init; }

    [JsonPropertyName("channels")]
    public List<OneOf<string, MessageRouting>> Channels { get; init; }
}
