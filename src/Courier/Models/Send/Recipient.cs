using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using RecipientVariants = Courier.Models.Send.RecipientVariants;

namespace Courier.Models.Send;

[JsonConverter(typeof(RecipientConverter))]
public abstract record class Recipient
{
    internal Recipient() { }

    public static implicit operator Recipient(UserRecipient value) =>
        new RecipientVariants::UserRecipient(value);

    public static implicit operator Recipient(ListRecipient value) =>
        new RecipientVariants::ListRecipient(value);

    public bool TryPickUser([NotNullWhen(true)] out UserRecipient? value)
    {
        value = (this as RecipientVariants::UserRecipient)?.Value;
        return value != null;
    }

    public bool TryPickList([NotNullWhen(true)] out ListRecipient? value)
    {
        value = (this as RecipientVariants::ListRecipient)?.Value;
        return value != null;
    }

    public void Switch(
        Action<RecipientVariants::UserRecipient> user,
        Action<RecipientVariants::ListRecipient> list
    )
    {
        switch (this)
        {
            case RecipientVariants::UserRecipient inner:
                user(inner);
                break;
            case RecipientVariants::ListRecipient inner:
                list(inner);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of Recipient"
                );
        }
    }

    public T Match<T>(
        Func<RecipientVariants::UserRecipient, T> user,
        Func<RecipientVariants::ListRecipient, T> list
    )
    {
        return this switch
        {
            RecipientVariants::UserRecipient inner => user(inner),
            RecipientVariants::ListRecipient inner => list(inner),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of Recipient"
            ),
        };
    }

    public abstract void Validate();
}

sealed class RecipientConverter : JsonConverter<Recipient>
{
    public override Recipient? Read(
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
                return new RecipientVariants::UserRecipient(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant RecipientVariants::UserRecipient",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ListRecipient>(ref reader, options);
            if (deserialized != null)
            {
                return new RecipientVariants::ListRecipient(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant RecipientVariants::ListRecipient",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        Recipient value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            RecipientVariants::UserRecipient(var user) => user,
            RecipientVariants::ListRecipient(var list) => list,
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of Recipient"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
