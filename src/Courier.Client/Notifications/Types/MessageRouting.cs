using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record MessageRouting
{
    [JsonPropertyName("method")]
    public required MessageRoutingMethod Method { get; set; }

    [JsonPropertyName("channels")]
    public IEnumerable<OneOf<string, MessageRouting>> Channels { get; set; } =
        new List<OneOf<string, MessageRouting>>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
