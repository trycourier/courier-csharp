using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record BrandSettingsInApp
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
    public required WidgetBackground WidgetBackground { get; init; }

    [JsonPropertyName("colors")]
    public required BrandColors Colors { get; init; }

    [JsonPropertyName("icons")]
    public required Icons Icons { get; init; }

    [JsonPropertyName("preferences")]
    public required Preferences Preferences { get; init; }
}
