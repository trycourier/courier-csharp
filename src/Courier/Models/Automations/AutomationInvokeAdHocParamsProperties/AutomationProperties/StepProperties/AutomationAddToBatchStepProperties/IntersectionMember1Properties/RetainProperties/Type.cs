using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToBatchStepProperties.IntersectionMember1Properties.RetainProperties;

/// <summary>
/// Keep N number of notifications based on the type. First/Last N based on notification
/// received. highest/lowest based on a scoring key providing in the data accessed
/// by sort_key
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    First,
    Last,
    Highest,
    Lowest,
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
            "first" => RetainProperties.Type.First,
            "last" => RetainProperties.Type.Last,
            "highest" => RetainProperties.Type.Highest,
            "lowest" => RetainProperties.Type.Lowest,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RetainProperties.Type.First => "first",
                RetainProperties.Type.Last => "last",
                RetainProperties.Type.Highest => "highest",
                RetainProperties.Type.Lowest => "lowest",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
