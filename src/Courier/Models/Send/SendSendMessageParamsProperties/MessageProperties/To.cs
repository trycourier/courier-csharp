using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ToProperties;
using ToVariants = Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ToVariants;

namespace Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties;

/// <summary>
/// The recipient or a list of recipients of the message
/// </summary>
[JsonConverter(typeof(ToConverter))]
public abstract record class To
{
    internal To() { }

    public static implicit operator To(UnionMember0 value) => new ToVariants::UnionMember0(value);

    public static implicit operator To(List<Recipient> value) => new ToVariants::Recipients(value);

    public bool TryPickUnionMember0([NotNullWhen(true)] out UnionMember0? value)
    {
        value = (this as ToVariants::UnionMember0)?.Value;
        return value != null;
    }

    public bool TryPickRecipients([NotNullWhen(true)] out List<Recipient>? value)
    {
        value = (this as ToVariants::Recipients)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ToVariants::UnionMember0> unionMember0,
        Action<ToVariants::Recipients> recipients
    )
    {
        switch (this)
        {
            case ToVariants::UnionMember0 inner:
                unionMember0(inner);
                break;
            case ToVariants::Recipients inner:
                recipients(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of To");
        }
    }

    public T Match<T>(
        Func<ToVariants::UnionMember0, T> unionMember0,
        Func<ToVariants::Recipients, T> recipients
    )
    {
        return this switch
        {
            ToVariants::UnionMember0 inner => unionMember0(inner),
            ToVariants::Recipients inner => recipients(inner),
            _ => throw new CourierInvalidDataException("Data did not match any variant of To"),
        };
    }

    public abstract void Validate();
}

sealed class ToConverter : JsonConverter<To?>
{
    public override To? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember0>(ref reader, options);
            if (deserialized != null)
            {
                return new ToVariants::UnionMember0(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ToVariants::UnionMember0",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Recipient>>(ref reader, options);
            if (deserialized != null)
            {
                return new ToVariants::Recipients(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ToVariants::Recipients",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, To? value, JsonSerializerOptions options)
    {
        object? variant = value switch
        {
            null => null,
            ToVariants::UnionMember0(var unionMember0) => unionMember0,
            ToVariants::Recipients(var recipients) => recipients,
            _ => throw new CourierInvalidDataException("Data did not match any variant of To"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
