using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Send.ElementalNodeProperties.UnionMember4Properties;

/// <summary>
/// The alignment of the action button. Defaults to "center".
/// </summary>
[JsonConverter(typeof(AlignConverter))]
public enum Align
{
    Center,
    Left,
    Right,
    Full,
}

sealed class AlignConverter : JsonConverter<Align>
{
    public override Align Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "center" => Align.Center,
            "left" => Align.Left,
            "right" => Align.Right,
            "full" => Align.Full,
            _ => (Align)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Align value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Align.Center => "center",
                Align.Left => "left",
                Align.Right => "right",
                Align.Full => "full",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
