using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record EmailHeader
{
    [JsonPropertyName("inheritDefault")]
    public bool? InheritDefault { get; init; }

    [JsonPropertyName("barColor")]
    public string? BarColor { get; init; }

    [JsonPropertyName("logo")]
    public required Logo Logo { get; init; }
}
