using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class BrandSettingsInApp
{
    [JsonPropertyName("borderRadius")]
    public string? BorderRadius { get; init; }

    [JsonPropertyName("disableMessageIcon")]
    public bool? DisableMessageIcon { get; init; }

    [JsonPropertyName("fontFamily")]
    public string? FontFamily { get; init; }

    [JsonPropertyName("placement")]
    public InAppPlacement? Placement { get; init; }

    [JsonPropertyName("widgetBackground")]
    public WidgetBackground WidgetBackground { get; init; }

    [JsonPropertyName("colors")]
    public BrandColors Colors { get; init; }

    [JsonPropertyName("icons")]
    public Icons Icons { get; init; }

    [JsonPropertyName("preferences")]
    public Preferences Preferences { get; init; }
}
