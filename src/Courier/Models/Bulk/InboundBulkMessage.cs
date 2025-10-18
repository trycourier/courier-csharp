using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Bulk.InboundBulkMessageProperties;

namespace Courier.Models.Bulk;

[JsonConverter(typeof(InboundBulkMessageConverter))]
public record class InboundBulkMessage
{
    public object Value { get; private init; }

    public string? Brand
    {
        get { return Match<string?>(template: (x) => x.Brand, content: (x) => x.Brand); }
    }

    public string? Event
    {
        get { return Match<string?>(template: (x) => x.Event, content: (x) => x.Event); }
    }

    public InboundBulkMessage(InboundBulkTemplateMessage value)
    {
        Value = value;
    }

    public InboundBulkMessage(InboundBulkContentMessage value)
    {
        Value = value;
    }

    InboundBulkMessage(UnknownVariant value)
    {
        Value = value;
    }

    public static InboundBulkMessage CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickTemplate([NotNullWhen(true)] out InboundBulkTemplateMessage? value)
    {
        value = this.Value as InboundBulkTemplateMessage;
        return value != null;
    }

    public bool TryPickContent([NotNullWhen(true)] out InboundBulkContentMessage? value)
    {
        value = this.Value as InboundBulkContentMessage;
        return value != null;
    }

    public void Switch(
        Action<InboundBulkTemplateMessage> template,
        Action<InboundBulkContentMessage> content
    )
    {
        switch (this.Value)
        {
            case InboundBulkTemplateMessage value:
                template(value);
                break;
            case InboundBulkContentMessage value:
                content(value);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of InboundBulkMessage"
                );
        }
    }

    public T Match<T>(
        Func<InboundBulkTemplateMessage, T> template,
        Func<InboundBulkContentMessage, T> content
    )
    {
        return this.Value switch
        {
            InboundBulkTemplateMessage value => template(value),
            InboundBulkContentMessage value => content(value),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of InboundBulkMessage"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new CourierInvalidDataException(
                "Data did not match any variant of InboundBulkMessage"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                deserialized.Validate();
                return new InboundBulkMessage(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'InboundBulkTemplateMessage'",
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
                deserialized.Validate();
                return new InboundBulkMessage(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'InboundBulkContentMessage'",
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
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
