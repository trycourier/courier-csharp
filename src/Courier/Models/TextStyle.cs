using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(TextStyleConverter))]
public enum TextStyle
{
    Text,
    H1,
    H2,
    Subtext,
}

sealed class TextStyleConverter : JsonConverter<TextStyle>
{
    public override TextStyle Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => TextStyle.Text,
            "h1" => TextStyle.H1,
            "h2" => TextStyle.H2,
            "subtext" => TextStyle.Subtext,
            _ => (TextStyle)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TextStyle value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TextStyle.Text => "text",
                TextStyle.H1 => "h1",
                TextStyle.H2 => "h2",
                TextStyle.Subtext => "subtext",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
