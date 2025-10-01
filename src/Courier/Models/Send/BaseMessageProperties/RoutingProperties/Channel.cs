using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Send.BaseMessageProperties.RoutingProperties.ChannelProperties;
using ChannelVariants = Courier.Models.Send.BaseMessageProperties.RoutingProperties.ChannelVariants;

namespace Courier.Models.Send.BaseMessageProperties.RoutingProperties;

[JsonConverter(typeof(ChannelConverter))]
public abstract record class Channel
{
    internal Channel() { }

    public static implicit operator Channel(RoutingStrategyChannel value) =>
        new ChannelVariants::RoutingStrategyChannel(value);

    public static implicit operator Channel(RoutingStrategyProvider value) =>
        new ChannelVariants::RoutingStrategyProvider(value);

    public static implicit operator Channel(string value) => new ChannelVariants::String(value);

    public bool TryPickRoutingStrategy([NotNullWhen(true)] out RoutingStrategyChannel? value)
    {
        value = (this as ChannelVariants::RoutingStrategyChannel)?.Value;
        return value != null;
    }

    public bool TryPickRoutingStrategyProvider(
        [NotNullWhen(true)] out RoutingStrategyProvider? value
    )
    {
        value = (this as ChannelVariants::RoutingStrategyProvider)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as ChannelVariants::String)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ChannelVariants::RoutingStrategyChannel> routingStrategy,
        Action<ChannelVariants::RoutingStrategyProvider> routingStrategyProvider,
        Action<ChannelVariants::String> @string
    )
    {
        switch (this)
        {
            case ChannelVariants::RoutingStrategyChannel inner:
                routingStrategy(inner);
                break;
            case ChannelVariants::RoutingStrategyProvider inner:
                routingStrategyProvider(inner);
                break;
            case ChannelVariants::String inner:
                @string(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Channel");
        }
    }

    public T Match<T>(
        Func<ChannelVariants::RoutingStrategyChannel, T> routingStrategy,
        Func<ChannelVariants::RoutingStrategyProvider, T> routingStrategyProvider,
        Func<ChannelVariants::String, T> @string
    )
    {
        return this switch
        {
            ChannelVariants::RoutingStrategyChannel inner => routingStrategy(inner),
            ChannelVariants::RoutingStrategyProvider inner => routingStrategyProvider(inner),
            ChannelVariants::String inner => @string(inner),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Channel"),
        };
    }

    public abstract void Validate();
}

sealed class ChannelConverter : JsonConverter<Channel>
{
    public override Channel? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<RoutingStrategyChannel>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ChannelVariants::RoutingStrategyChannel(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ChannelVariants::RoutingStrategyChannel",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<RoutingStrategyProvider>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ChannelVariants::RoutingStrategyProvider(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ChannelVariants::RoutingStrategyProvider",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new ChannelVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ChannelVariants::String",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Channel value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ChannelVariants::RoutingStrategyChannel(var routingStrategy) => routingStrategy,
            ChannelVariants::RoutingStrategyProvider(var routingStrategyProvider) =>
                routingStrategyProvider,
            ChannelVariants::String(var @string) => @string,
            _ => throw new CourierInvalidDataException("Data did not match any variant of Channel"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
