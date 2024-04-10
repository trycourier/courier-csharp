using System.Text.Json.Serialization;
using Courier.Net;
using OneOf;

namespace Courier.Net;

public class Routing
{
    [JsonPropertyName("method")]
    public RoutingMethod Method { get; init; }

    /// <summary>
    /// A list of channels or providers to send the message through. Can also recursively define
    /// sub-routing methods, which can be useful for defining advanced push notification
    /// delivery strategies.
    /// </summary>
    [JsonPropertyName("channels")]
    public List<OneOf<RoutingStrategyChannel, RoutingStrategyProvider, string>> Channels { get; init; }
}
