using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record EmailHeader
{
    [JsonPropertyName("inheritDefault")]
    public bool? InheritDefault { get; init; }

    [JsonPropertyName("barColor")]
    public string? BarColor { get; init; }

    [JsonPropertyName("logo")]
    public required Logo Logo { get; init; }
}
