using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Tenants.Templates;

[JsonConverter(typeof(AlignmentConverter))]
public enum Alignment
{
    Center,
    Left,
    Right,
    Full,
}

sealed class AlignmentConverter : JsonConverter<Alignment>
{
    public override Alignment Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "center" => Alignment.Center,
            "left" => Alignment.Left,
            "right" => Alignment.Right,
            "full" => Alignment.Full,
            _ => (Alignment)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Alignment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Alignment.Center => "center",
                Alignment.Left => "left",
                Alignment.Right => "right",
                Alignment.Full => "full",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
