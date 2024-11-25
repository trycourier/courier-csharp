using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record EmailHeader
{
    [JsonPropertyName("inheritDefault")]
    public bool? InheritDefault { get; set; }

    [JsonPropertyName("barColor")]
    public string? BarColor { get; set; }

    [JsonPropertyName("logo")]
    public required Logo Logo { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
