using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(MessageRoutingChannelConverter))]
public record class MessageRoutingChannel
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public MessageRoutingChannel(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MessageRoutingChannel(MessageRouting value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MessageRoutingChannel(JsonElement json)
    {
        this._json = json;
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

    public static implicit operator MessageRoutingChannel(string value) => new(value);

    public static implicit operator MessageRoutingChannel(MessageRouting value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new CourierInvalidDataException(
                "Data did not match any variant of MessageRoutingChannel"
            );
        }
    }
}

sealed class MessageRoutingChannelConverter : JsonConverter<MessageRoutingChannel>
{
    public override MessageRoutingChannel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<MessageRouting>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageRoutingChannel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
