using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record EmailHead
{
    [JsonPropertyName("inheritDefault")]
    public required bool InheritDefault { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
