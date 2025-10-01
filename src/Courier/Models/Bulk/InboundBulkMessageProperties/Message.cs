using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Bulk.InboundBulkMessageProperties.MessageProperties;
using MessageVariants = Courier.Models.Bulk.InboundBulkMessageProperties.MessageVariants;

namespace Courier.Models.Bulk.InboundBulkMessageProperties;

/// <summary>
/// Describes the content of the message in a way that will  work for email, push,
/// chat, or any channel.
/// </summary>
[JsonConverter(typeof(MessageConverter))]
public abstract record class Message
{
    internal Message() { }

    public static implicit operator Message(InboundBulkTemplateMessage value) =>
        new MessageVariants::InboundBulkTemplateMessage(value);

    public static implicit operator Message(InboundBulkContentMessage value) =>
        new MessageVariants::InboundBulkContentMessage(value);

    public bool TryPickInboundBulkTemplate(
        [NotNullWhen(true)] out InboundBulkTemplateMessage? value
    )
    {
        value = (this as MessageVariants::InboundBulkTemplateMessage)?.Value;
        return value != null;
    }

    public bool TryPickInboundBulkContent([NotNullWhen(true)] out InboundBulkContentMessage? value)
    {
        value = (this as MessageVariants::InboundBulkContentMessage)?.Value;
        return value != null;
    }

    public void Switch(
        Action<MessageVariants::InboundBulkTemplateMessage> inboundBulkTemplate,
        Action<MessageVariants::InboundBulkContentMessage> inboundBulkContent
    )
    {
        switch (this)
        {
            case MessageVariants::InboundBulkTemplateMessage inner:
                inboundBulkTemplate(inner);
                break;
            case MessageVariants::InboundBulkContentMessage inner:
                inboundBulkContent(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Message");
        }
    }

    public T Match<T>(
        Func<MessageVariants::InboundBulkTemplateMessage, T> inboundBulkTemplate,
        Func<MessageVariants::InboundBulkContentMessage, T> inboundBulkContent
    )
    {
        return this switch
        {
            MessageVariants::InboundBulkTemplateMessage inner => inboundBulkTemplate(inner),
            MessageVariants::InboundBulkContentMessage inner => inboundBulkContent(inner),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Message"),
        };
    }

    public abstract void Validate();
}

sealed class MessageConverter : JsonConverter<Message?>
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
            var deserialized = JsonSerializer.Deserialize<InboundBulkTemplateMessage>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new MessageVariants::InboundBulkTemplateMessage(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant MessageVariants::InboundBulkTemplateMessage",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<InboundBulkContentMessage>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new MessageVariants::InboundBulkContentMessage(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant MessageVariants::InboundBulkContentMessage",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Message? value, JsonSerializerOptions options)
    {
        object? variant = value switch
        {
            null => null,
            MessageVariants::InboundBulkTemplateMessage(var inboundBulkTemplate) =>
                inboundBulkTemplate,
            MessageVariants::InboundBulkContentMessage(var inboundBulkContent) =>
                inboundBulkContent,
            _ => throw new CourierInvalidDataException("Data did not match any variant of Message"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
