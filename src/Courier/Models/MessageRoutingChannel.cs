using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(MessageRoutingChannelConverter))]
public record class MessageRoutingChannel
{
    public object Value { get; private init; }

    public MessageRoutingChannel(string value)
    {
        Value = value;
    }

    public MessageRoutingChannel(MessageRouting value)
    {
        Value = value;
    }

    MessageRoutingChannel(UnknownVariant value)
    {
        Value = value;
    }

    public static MessageRoutingChannel CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickMessageRouting([NotNullWhen(true)] out MessageRouting? value)
    {
        value = this.Value as MessageRouting;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<MessageRouting> messageRouting
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case MessageRouting value:
                messageRouting(value);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of MessageRoutingChannel"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<MessageRouting, T> messageRouting
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            MessageRouting value => messageRouting(value),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of MessageRoutingChannel"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new CourierInvalidDataException(
                "Data did not match any variant of MessageRoutingChannel"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class MessageRoutingChannelConverter : JsonConverter<MessageRoutingChannel>
{
    public override MessageRoutingChannel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<MessageRouting>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new MessageRoutingChannel(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'MessageRouting'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new MessageRoutingChannel(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException("Data does not match union variant 'string'", e)
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageRoutingChannel value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
