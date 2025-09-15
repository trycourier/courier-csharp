using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record Routing
{
    [JsonPropertyName("method")]
    public required RoutingMethod Method { get; set; }

    /// <summary>
    /// A list of channels or providers to send the message through. Can also recursively define
    /// sub-routing methods, which can be useful for defining advanced push notification
    /// delivery strategies.
    /// </summary>
    [JsonPropertyName("channels")]
    public IEnumerable<OneOf<string, MessageRouting>> Channels { get; set; } =
        new List<OneOf<string, MessageRouting>>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
