using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Brands.BrandSnippetsProperties.ItemProperties;

[JsonConverter(typeof(FormatConverter))]
public enum Format
{
    Handlebars,
}

sealed class FormatConverter : JsonConverter<Format>
{
    public override Format Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "handlebars" => Format.Handlebars,
            _ => (Format)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Format value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Format.Handlebars => "handlebars",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
