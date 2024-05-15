using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class EmailHeader
{
    [JsonPropertyName("inheritDefault")]
    public bool? InheritDefault { get; init; }

    [JsonPropertyName("barColor")]
    public string? BarColor { get; init; }

    [JsonPropertyName("logo")]
    public Logo Logo { get; init; }
}
