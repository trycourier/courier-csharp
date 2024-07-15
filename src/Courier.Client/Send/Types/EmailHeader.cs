using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record EmailHeader
{
    [JsonPropertyName("inheritDefault")]
    public bool? InheritDefault { get; init; }

    [JsonPropertyName("barColor")]
    public string? BarColor { get; init; }

    [JsonPropertyName("logo")]
    public required Logo Logo { get; init; }
}
