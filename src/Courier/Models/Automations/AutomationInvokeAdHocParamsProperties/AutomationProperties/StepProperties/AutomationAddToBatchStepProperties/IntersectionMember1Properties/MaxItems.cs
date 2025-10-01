using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToBatchStepProperties.IntersectionMember1Properties.MaxItemsVariants;
using System = System;

namespace Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToBatchStepProperties.IntersectionMember1Properties;

/// <summary>
/// If specified, the batch will release as soon as this number is reached
/// </summary>
[JsonConverter(typeof(MaxItemsConverter))]
public abstract record class MaxItems
{
    internal MaxItems() { }

    public static implicit operator MaxItems(string value) => new String(value);

    public static implicit operator MaxItems(long value) => new Long(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as String)?.Value;
        return value != null;
    }

    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = (this as Long)?.Value;
        return value != null;
    }

    public void Switch(System::Action<String> @string, System::Action<Long> @long)
    {
        switch (this)
        {
            case String inner:
                @string(inner);
                break;
            case Long inner:
                @long(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of MaxItems");
        }
    }

    public T Match<T>(System::Func<String, T> @string, System::Func<Long, T> @long)
    {
        return this switch
        {
            String inner => @string(inner),
            Long inner => @long(inner),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of MaxItems"
            ),
        };
    }

    public abstract void Validate();
}

sealed class MaxItemsConverter : JsonConverter<MaxItems?>
{
    public override MaxItems? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException("Data does not match union variant String", e)
            );
        }

        try
        {
            return new Long(JsonSerializer.Deserialize<long>(ref reader, options));
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException("Data does not match union variant Long", e)
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        MaxItems? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value switch
        {
            null => null,
            String(var @string) => @string,
            Long(var @long) => @long,
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of MaxItems"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
