using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;
using OneOf;

#nullable enable

namespace Courier.Net;

public record MessageRouting
{
    [JsonPropertyName("method")]
    public required MessageRoutingMethod Method { get; init; }

    [JsonPropertyName("channels")]
    [JsonConverter(
        typeof(CollectionItemSerializer<
            OneOf<string, MessageRouting>,
            OneOfSerializer<OneOf<string, MessageRouting>>
        >)
    )]
    public IEnumerable<OneOf<string, MessageRouting>> Channels { get; init; } =
        new List<OneOf<string, MessageRouting>>();
}
