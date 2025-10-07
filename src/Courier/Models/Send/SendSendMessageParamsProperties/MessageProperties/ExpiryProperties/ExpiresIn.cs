using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using ExpiresInVariants = Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ExpiryProperties.ExpiresInVariants;

namespace Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ExpiryProperties;

/// <summary>
/// Duration in ms or ISO8601 duration (e.g. P1DT4H).
/// </summary>
[JsonConverter(typeof(ExpiresInConverter))]
public abstract record class ExpiresIn
{
    internal ExpiresIn() { }

    public static implicit operator ExpiresIn(string value) => new ExpiresInVariants::String(value);

    public static implicit operator ExpiresIn(long value) => new ExpiresInVariants::Long(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as ExpiresInVariants::String)?.Value;
        return value != null;
    }

    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = (this as ExpiresInVariants::Long)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ExpiresInVariants::String> @string,
        Action<ExpiresInVariants::Long> @long
    )
    {
        switch (this)
        {
            case ExpiresInVariants::String inner:
                @string(inner);
                break;
            case ExpiresInVariants::Long inner:
                @long(inner);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of ExpiresIn"
                );
        }
    }

    public T Match<T>(
        Func<ExpiresInVariants::String, T> @string,
        Func<ExpiresInVariants::Long, T> @long
    )
    {
        return this switch
        {
            ExpiresInVariants::String inner => @string(inner),
            ExpiresInVariants::Long inner => @long(inner),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of ExpiresIn"
            ),
        };
    }

    public abstract void Validate();
}

sealed class ExpiresInConverter : JsonConverter<ExpiresIn>
{
    public override ExpiresIn? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new ExpiresInVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ExpiresInVariants::String",
                    e
                )
            );
        }

        try
        {
            return new ExpiresInVariants::Long(
                JsonSerializer.Deserialize<long>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ExpiresInVariants::Long",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExpiresIn value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ExpiresInVariants::String(var @string) => @string,
            ExpiresInVariants::Long(var @long) => @long,
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of ExpiresIn"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
