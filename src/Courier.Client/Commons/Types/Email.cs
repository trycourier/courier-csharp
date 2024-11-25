using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record Email
{
    [JsonPropertyName("footer")]
    public required object Footer { get; set; }

    [JsonPropertyName("header")]
    public required object Header { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
