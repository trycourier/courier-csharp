using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Brands.BrandSettingsInAppProperties;

[JsonConverter(typeof(PlacementConverter))]
public enum Placement
{
    Top,
    Bottom,
    Left,
    Right,
}

sealed class PlacementConverter : JsonConverter<Placement>
{
    public override Placement Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "top" => Placement.Top,
            "bottom" => Placement.Bottom,
            "left" => Placement.Left,
            "right" => Placement.Right,
            _ => (Placement)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Placement value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Placement.Top => "top",
                Placement.Bottom => "bottom",
                Placement.Left => "left",
                Placement.Right => "right",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
