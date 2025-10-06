using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using ExpiryDateVariants = Courier.Models.Users.Tokens.TokenAddSingleParamsProperties.ExpiryDateVariants;

namespace Courier.Models.Users.Tokens.TokenAddSingleParamsProperties;

/// <summary>
/// ISO 8601 formatted date the token expires. Defaults to 2 months. Set to false
/// to disable expiration.
/// </summary>
[JsonConverter(typeof(ExpiryDateConverter))]
public abstract record class ExpiryDate
{
    internal ExpiryDate() { }

    public static implicit operator ExpiryDate(string value) =>
        new ExpiryDateVariants::String(value);

    public static implicit operator ExpiryDate(bool value) => new ExpiryDateVariants::Bool(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as ExpiryDateVariants::String)?.Value;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = (this as ExpiryDateVariants::Bool)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ExpiryDateVariants::String> @string,
        Action<ExpiryDateVariants::Bool> @bool
    )
    {
        switch (this)
        {
            case ExpiryDateVariants::String inner:
                @string(inner);
                break;
            case ExpiryDateVariants::Bool inner:
                @bool(inner);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of ExpiryDate"
                );
        }
    }

    public T Match<T>(
        Func<ExpiryDateVariants::String, T> @string,
        Func<ExpiryDateVariants::Bool, T> @bool
    )
    {
        return this switch
        {
            ExpiryDateVariants::String inner => @string(inner),
            ExpiryDateVariants::Bool inner => @bool(inner),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of ExpiryDate"
            ),
        };
    }

    public abstract void Validate();
}

sealed class ExpiryDateConverter : JsonConverter<ExpiryDate?>
{
    public override ExpiryDate? Read(
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
                return new ExpiryDateVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ExpiryDateVariants::String",
                    e
                )
            );
        }

        try
        {
            return new ExpiryDateVariants::Bool(
                JsonSerializer.Deserialize<bool>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ExpiryDateVariants::Bool",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExpiryDate? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value switch
        {
            null => null,
            ExpiryDateVariants::String(var @string) => @string,
            ExpiryDateVariants::Bool(var @bool) => @bool,
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of ExpiryDate"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
