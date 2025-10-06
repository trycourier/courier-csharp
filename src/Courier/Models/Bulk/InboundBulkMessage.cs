using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Bulk.InboundBulkMessageProperties;
using InboundBulkMessageVariants = Courier.Models.Bulk.InboundBulkMessageVariants;

namespace Courier.Models.Bulk;

[JsonConverter(typeof(InboundBulkMessageConverter))]
public abstract record class InboundBulkMessage
{
    internal InboundBulkMessage() { }

    public static implicit operator InboundBulkMessage(InboundBulkTemplateMessage value) =>
        new InboundBulkMessageVariants::InboundBulkTemplateMessage(value);

    public static implicit operator InboundBulkMessage(InboundBulkContentMessage value) =>
        new InboundBulkMessageVariants::InboundBulkContentMessage(value);

    public bool TryPickTemplate([NotNullWhen(true)] out InboundBulkTemplateMessage? value)
    {
        value = (this as InboundBulkMessageVariants::InboundBulkTemplateMessage)?.Value;
        return value != null;
    }

    public bool TryPickContent([NotNullWhen(true)] out InboundBulkContentMessage? value)
    {
        value = (this as InboundBulkMessageVariants::InboundBulkContentMessage)?.Value;
        return value != null;
    }

    public void Switch(
        Action<InboundBulkMessageVariants::InboundBulkTemplateMessage> template,
        Action<InboundBulkMessageVariants::InboundBulkContentMessage> content
    )
    {
        switch (this)
        {
            case InboundBulkMessageVariants::InboundBulkTemplateMessage inner:
                template(inner);
                break;
            case InboundBulkMessageVariants::InboundBulkContentMessage inner:
                content(inner);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of InboundBulkMessage"
                );
        }
    }

    public T Match<T>(
        Func<InboundBulkMessageVariants::InboundBulkTemplateMessage, T> template,
        Func<InboundBulkMessageVariants::InboundBulkContentMessage, T> content
    )
    {
        return this switch
        {
            InboundBulkMessageVariants::InboundBulkTemplateMessage inner => template(inner),
            InboundBulkMessageVariants::InboundBulkContentMessage inner => content(inner),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of InboundBulkMessage"
            ),
        };
    }

    public abstract void Validate();
}

sealed class InboundBulkMessageConverter : JsonConverter<InboundBulkMessage>
{
    public override InboundBulkMessage? Read(
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
                return new InboundBulkMessageVariants::InboundBulkTemplateMessage(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant InboundBulkMessageVariants::InboundBulkTemplateMessage",
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
                return new InboundBulkMessageVariants::InboundBulkContentMessage(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant InboundBulkMessageVariants::InboundBulkContentMessage",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundBulkMessage value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            InboundBulkMessageVariants::InboundBulkTemplateMessage(var template) => template,
            InboundBulkMessageVariants::InboundBulkContentMessage(var content) => content,
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of InboundBulkMessage"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
