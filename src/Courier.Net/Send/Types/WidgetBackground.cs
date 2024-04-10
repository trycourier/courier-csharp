using System.Text.Json.Serialization;

namespace Courier.Net;

public class WidgetBackground
{
    [JsonPropertyName("topColor")]
    public string? TopColor { get; init; }

    [JsonPropertyName("bottomColor")]
    public string? BottomColor { get; init; }
}
