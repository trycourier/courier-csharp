using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record Timeouts
{
    [JsonPropertyName("provider")]
    public int? Provider { get; set; }

    [JsonPropertyName("channel")]
    public int? Channel { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
