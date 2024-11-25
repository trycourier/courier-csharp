using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record WidgetBackground
{
    [JsonPropertyName("topColor")]
    public string? TopColor { get; set; }

    [JsonPropertyName("bottomColor")]
    public string? BottomColor { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
