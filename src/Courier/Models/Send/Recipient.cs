using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Bulk;
using Courier.Models.Send.RecipientProperties;

namespace Courier.Models.Send;

[JsonConverter(typeof(RecipientConverter))]
public record class Recipient
{
    public object Value { get; private init; }

    public Recipient(UserRecipient value)
    {
        Value = value;
    }

    public Recipient(ListRecipient value)
    {
        Value = value;
    }

    Recipient(UnknownVariant value)
    {
        Value = value;
    }

    public static Recipient CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUser([NotNullWhen(true)] out UserRecipient? value)
    {
        value = this.Value as UserRecipient;
        return value != null;
    }

    public bool TryPickList([NotNullWhen(true)] out ListRecipient? value)
    {
        value = this.Value as ListRecipient;
        return value != null;
    }

    public void Switch(Action<UserRecipient> user, Action<ListRecipient> list)
    {
        switch (this.Value)
        {
            case UserRecipient value:
                user(value);
                break;
            case ListRecipient value:
                list(value);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of Recipient"
                );
        }
    }

    public T Match<T>(Func<UserRecipient, T> user, Func<ListRecipient, T> list)
    {
        return this.Value switch
        {
            UserRecipient value => user(value),
            ListRecipient value => list(value),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of Recipient"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new CourierInvalidDataException("Data did not match any variant of Recipient");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                deserialized.Validate();
                return new Recipient(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'UserRecipient'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ListRecipient>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Recipient(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'ListRecipient'",
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
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
