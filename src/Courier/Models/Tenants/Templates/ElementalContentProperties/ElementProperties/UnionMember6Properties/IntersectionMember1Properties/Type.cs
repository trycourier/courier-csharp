using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Tenants.Templates.ElementalContentProperties.ElementProperties.UnionMember6Properties.IntersectionMember1Properties;

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Quote,
}

sealed class TypeConverter : JsonConverter<Type>
{
    public override Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "quote" => IntersectionMember1Properties.Type.Quote,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntersectionMember1Properties.Type.Quote => "quote",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
