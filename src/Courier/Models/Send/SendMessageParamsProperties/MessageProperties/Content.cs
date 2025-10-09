using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Send.SendMessageParamsProperties.MessageProperties;

/// <summary>
/// Describes content that will work for email, inbox, push, chat, or any channel id.
/// </summary>
[JsonConverter(typeof(ContentConverter))]
public record class Content
{
    public object Value { get; private init; }

    public Content(ElementalContentSugar value)
    {
        Value = value;
    }

    public Content(ElementalContent value)
    {
        Value = value;
    }

    Content(UnknownVariant value)
    {
        Value = value;
    }

    public static Content CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickElementalContentSugar([NotNullWhen(true)] out ElementalContentSugar? value)
    {
        value = this.Value as ElementalContentSugar;
        return value != null;
    }

    public bool TryPickElemental([NotNullWhen(true)] out ElementalContent? value)
    {
        value = this.Value as ElementalContent;
        return value != null;
    }

    public void Switch(
        Action<ElementalContentSugar> elementalContentSugar,
        Action<ElementalContent> elemental
    )
    {
        switch (this.Value)
        {
            case ElementalContentSugar value:
                elementalContentSugar(value);
                break;
            case ElementalContent value:
                elemental(value);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Content");
        }
    }

    public T Match<T>(
        Func<ElementalContentSugar, T> elementalContentSugar,
        Func<ElementalContent, T> elemental
    )
    {
        return this.Value switch
        {
            ElementalContentSugar value => elementalContentSugar(value),
            ElementalContent value => elemental(value),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Content"),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new CourierInvalidDataException("Data did not match any variant of Content");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class ContentConverter : JsonConverter<Content>
{
    public override Content? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalContentSugar>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'ElementalContentSugar'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalContent>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'ElementalContent'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
