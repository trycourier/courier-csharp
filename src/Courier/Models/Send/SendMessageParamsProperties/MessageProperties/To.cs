using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Bulk;
using ToVariants = Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ToVariants;

namespace Courier.Models.Send.SendMessageParamsProperties.MessageProperties;

/// <summary>
/// The recipient or a list of recipients of the message
/// </summary>
[JsonConverter(typeof(ToConverter))]
public abstract record class To
{
    internal To() { }

    public static implicit operator To(UserRecipient value) => new ToVariants::UserRecipient(value);

    public static implicit operator To(List<Recipient> value) => new ToVariants::Recipients(value);

    public bool TryPickUserRecipient([NotNullWhen(true)] out UserRecipient? value)
    {
        value = (this as ToVariants::UserRecipient)?.Value;
        return value != null;
    }

    public bool TryPickRecipients([NotNullWhen(true)] out List<Recipient>? value)
    {
        value = (this as ToVariants::Recipients)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ToVariants::UserRecipient> userRecipient,
        Action<ToVariants::Recipients> recipients
    )
    {
        switch (this)
        {
            case ToVariants::UserRecipient inner:
                userRecipient(inner);
                break;
            case ToVariants::Recipients inner:
                recipients(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of To");
        }
    }

    public T Match<T>(
        Func<ToVariants::UserRecipient, T> userRecipient,
        Func<ToVariants::Recipients, T> recipients
    )
    {
        return this switch
        {
            ToVariants::UserRecipient inner => userRecipient(inner),
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
            var deserialized = JsonSerializer.Deserialize<UserRecipient>(ref reader, options);
            if (deserialized != null)
            {
                return new ToVariants::UserRecipient(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ToVariants::UserRecipient",
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
            ToVariants::UserRecipient(var userRecipient) => userRecipient,
            ToVariants::Recipients(var recipients) => recipients,
            _ => throw new CourierInvalidDataException("Data did not match any variant of To"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
