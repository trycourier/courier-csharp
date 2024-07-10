using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record WidgetBackground
{
    [JsonPropertyName("topColor")]
    public string? TopColor { get; init; }

    [JsonPropertyName("bottomColor")]
    public string? BottomColor { get; init; }
}
