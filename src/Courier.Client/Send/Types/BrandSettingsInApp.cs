using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BrandSettingsInApp
{
    [JsonPropertyName("borderRadius")]
    public string? BorderRadius { get; set; }

    [JsonPropertyName("disableMessageIcon")]
    public bool? DisableMessageIcon { get; set; }

    [JsonPropertyName("fontFamily")]
    public string? FontFamily { get; set; }

    [JsonPropertyName("placement")]
    public InAppPlacement? Placement { get; set; }

    [JsonPropertyName("widgetBackground")]
    public required WidgetBackground WidgetBackground { get; set; }

    [JsonPropertyName("colors")]
    public required BrandColors Colors { get; set; }

    [JsonPropertyName("icons")]
    public required Icons Icons { get; set; }

    [JsonPropertyName("preferences")]
    public required Preferences Preferences { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
