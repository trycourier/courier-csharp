using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Send.MessageProperties;
using MessageVariants = Courier.Models.Send.MessageVariants;

namespace Courier.Models.Send;

/// <summary>
/// Describes the content of the message in a way that will work for email, push,
/// chat, or any channel.
/// </summary>
[JsonConverter(typeof(MessageConverter))]
public abstract record class Message
{
    internal Message() { }

    public static implicit operator Message(ContentMessage value) =>
        new MessageVariants::ContentMessage(value);

    public static implicit operator Message(TemplateMessage value) =>
        new MessageVariants::TemplateMessage(value);

    public bool TryPickContent([NotNullWhen(true)] out ContentMessage? value)
    {
        value = (this as MessageVariants::ContentMessage)?.Value;
        return value != null;
    }

    public bool TryPickTemplate([NotNullWhen(true)] out TemplateMessage? value)
    {
        value = (this as MessageVariants::TemplateMessage)?.Value;
        return value != null;
    }

    public void Switch(
        Action<MessageVariants::ContentMessage> content,
        Action<MessageVariants::TemplateMessage> template
    )
    {
        switch (this)
        {
            case MessageVariants::ContentMessage inner:
                content(inner);
                break;
            case MessageVariants::TemplateMessage inner:
                template(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Message");
        }
    }

    public T Match<T>(
        Func<MessageVariants::ContentMessage, T> content,
        Func<MessageVariants::TemplateMessage, T> template
    )
    {
        return this switch
        {
            MessageVariants::ContentMessage inner => content(inner),
            MessageVariants::TemplateMessage inner => template(inner),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Message"),
        };
    }

    public abstract void Validate();
}

sealed class MessageConverter : JsonConverter<Message>
{
    public override Message? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<ContentMessage>(ref reader, options);
            if (deserialized != null)
            {
                return new MessageVariants::ContentMessage(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant MessageVariants::ContentMessage",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<TemplateMessage>(ref reader, options);
            if (deserialized != null)
            {
                return new MessageVariants::TemplateMessage(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant MessageVariants::TemplateMessage",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Message value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            MessageVariants::ContentMessage(var content) => content,
            MessageVariants::TemplateMessage(var template) => template,
            _ => throw new CourierInvalidDataException("Data did not match any variant of Message"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
