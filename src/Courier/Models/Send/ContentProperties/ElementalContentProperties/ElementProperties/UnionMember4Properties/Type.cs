using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Send.ContentProperties.ElementalContentProperties.ElementProperties.UnionMember4Properties;

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Action,
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
            "action" => UnionMember4Properties.Type.Action,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionMember4Properties.Type.Action => "action",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
