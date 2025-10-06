using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Send.ElementalNodeProperties.UnionMember4Properties;

/// <summary>
/// Defaults to `button`.
/// </summary>
[JsonConverter(typeof(StyleConverter))]
public enum Style
{
    Button,
    Link,
}

sealed class StyleConverter : JsonConverter<Style>
{
    public override Style Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "button" => Style.Button,
            "link" => Style.Link,
            _ => (Style)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Style value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Style.Button => "button",
                Style.Link => "link",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
