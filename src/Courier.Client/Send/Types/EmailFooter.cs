using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record EmailFooter
{
    [JsonPropertyName("content")]
    public object? Content { get; set; }

    [JsonPropertyName("inheritDefault")]
    public bool? InheritDefault { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
