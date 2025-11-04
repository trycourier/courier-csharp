using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ExpiryProperties;

/// <summary>
/// Duration in ms or ISO8601 duration (e.g. P1DT4H).
/// </summary>
[JsonConverter(typeof(ExpiresInConverter))]
public record class ExpiresIn
{
    public object Value { get; private init; }

    public ExpiresIn(string value)
    {
        Value = value;
    }

    public ExpiresIn(long value)
    {
        Value = value;
    }

    ExpiresIn(UnknownVariant value)
    {
        Value = value;
    }

    public static ExpiresIn CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
        return value != null;
    }

    public void Switch(Action<string> @string, Action<long> @long)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case long value:
                @long(value);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of ExpiresIn"
                );
        }
    }

    public T Match<T>(Func<string, T> @string, Func<long, T> @long)
    {
        return this.Value switch
        {
            string value => @string(value),
            long value => @long(value),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of ExpiresIn"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new CourierInvalidDataException("Data did not match any variant of ExpiresIn");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                return new ExpiresIn(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException("Data does not match union variant 'string'", e)
            );
        }

        try
        {
            return new ExpiresIn(JsonSerializer.Deserialize<long>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException("Data does not match union variant 'long'", e)
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
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
