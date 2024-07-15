using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record Routing
{
    [JsonPropertyName("method")]
    public required RoutingMethod Method { get; init; }

    /// <summary>
    /// A list of channels or providers to send the message through. Can also recursively define
    /// sub-routing methods, which can be useful for defining advanced push notification
    /// delivery strategies.
    /// </summary>
    [JsonPropertyName("channels")]
    [JsonConverter(
        typeof(CollectionItemSerializer<
            OneOf<RoutingStrategyChannel, RoutingStrategyProvider, string>,
            OneOfSerializer<OneOf<RoutingStrategyChannel, RoutingStrategyProvider, string>>
        >)
    )]
    public IEnumerable<
        OneOf<RoutingStrategyChannel, RoutingStrategyProvider, string>
    > Channels { get; init; } =
        new List<OneOf<RoutingStrategyChannel, RoutingStrategyProvider, string>>();
}
