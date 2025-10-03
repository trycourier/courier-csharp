using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using MessageRoutingChannelVariants = Courier.Models.Send.MessageRoutingChannelVariants;

namespace Courier.Models.Send;

[JsonConverter(typeof(MessageRoutingChannelConverter))]
public abstract record class MessageRoutingChannel
{
    internal MessageRoutingChannel() { }

    public static implicit operator MessageRoutingChannel(string value) =>
        new MessageRoutingChannelVariants::String(value);

    public static implicit operator MessageRoutingChannel(MessageRouting value) =>
        new MessageRoutingChannelVariants::MessageRouting(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as MessageRoutingChannelVariants::String)?.Value;
        return value != null;
    }

    public bool TryPickMessageRouting([NotNullWhen(true)] out MessageRouting? value)
    {
        value = (this as MessageRoutingChannelVariants::MessageRouting)?.Value;
        return value != null;
    }

    public void Switch(
        Action<MessageRoutingChannelVariants::String> @string,
        Action<MessageRoutingChannelVariants::MessageRouting> messageRouting
    )
    {
        switch (this)
        {
            case MessageRoutingChannelVariants::String inner:
                @string(inner);
                break;
            case MessageRoutingChannelVariants::MessageRouting inner:
                messageRouting(inner);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of MessageRoutingChannel"
                );
        }
    }

    public T Match<T>(
        Func<MessageRoutingChannelVariants::String, T> @string,
        Func<MessageRoutingChannelVariants::MessageRouting, T> messageRouting
    )
    {
        return this switch
        {
            MessageRoutingChannelVariants::String inner => @string(inner),
            MessageRoutingChannelVariants::MessageRouting inner => messageRouting(inner),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of MessageRoutingChannel"
            ),
        };
    }

    public abstract void Validate();
}

sealed class MessageRoutingChannelConverter : JsonConverter<MessageRoutingChannel>
{
    public override MessageRoutingChannel? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<MessageRouting>(ref reader, options);
            if (deserialized != null)
            {
                return new MessageRoutingChannelVariants::MessageRouting(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant MessageRoutingChannelVariants::MessageRouting",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new MessageRoutingChannelVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant MessageRoutingChannelVariants::String",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageRoutingChannel value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            MessageRoutingChannelVariants::String(var @string) => @string,
            MessageRoutingChannelVariants::MessageRouting(var messageRouting) => messageRouting,
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of MessageRoutingChannel"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
