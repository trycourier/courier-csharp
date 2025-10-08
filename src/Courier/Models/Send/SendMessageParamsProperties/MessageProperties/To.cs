using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Send.SendMessageParamsProperties.MessageProperties;

/// <summary>
/// The recipient or a list of recipients of the message
/// </summary>
[JsonConverter(typeof(ToConverter))]
public record class To
{
    public object Value { get; private init; }

    public To(UserRecipient value)
    {
        Value = value;
    }

    public To(ListRecipient value)
    {
        Value = value;
    }

    public To(List<Recipient> value)
    {
        Value = value;
    }

    To(UnknownVariant value)
    {
        Value = value;
    }

    public static To CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUserRecipient([NotNullWhen(true)] out UserRecipient? value)
    {
        value = this.Value as UserRecipient;
        return value != null;
    }

    public bool TryPickListRecipient([NotNullWhen(true)] out ListRecipient? value)
    {
        value = this.Value as ListRecipient;
        return value != null;
    }

    public bool TryPickRecipients([NotNullWhen(true)] out List<Recipient>? value)
    {
        value = this.Value as List<Recipient>;
        return value != null;
    }

    public void Switch(
        Action<UserRecipient> userRecipient,
        Action<ListRecipient> listRecipient,
        Action<List<Recipient>> recipients
    )
    {
        switch (this.Value)
        {
            case UserRecipient value:
                userRecipient(value);
                break;
            case ListRecipient value:
                listRecipient(value);
                break;
            case List<Recipient> value:
                recipients(value);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of To");
        }
    }

    public T Match<T>(
        Func<UserRecipient, T> userRecipient,
        Func<ListRecipient, T> listRecipient,
        Func<List<Recipient>, T> recipients
    )
    {
        return this.Value switch
        {
            UserRecipient value => userRecipient(value),
            ListRecipient value => listRecipient(value),
            List<Recipient> value => recipients(value),
            _ => throw new CourierInvalidDataException("Data did not match any variant of To"),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new CourierInvalidDataException("Data did not match any variant of To");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                deserialized.Validate();
                return new To(deserialized);
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
                return new To(deserialized);
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

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Recipient>>(ref reader, options);
            if (deserialized != null)
            {
                return new To(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'List<Recipient>'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, To? value, JsonSerializerOptions options)
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
