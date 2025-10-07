using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Tenants.Templates;
using ContentVariants = Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ContentVariants;

namespace Courier.Models.Send.SendMessageParamsProperties.MessageProperties;

/// <summary>
/// Describes content that will work for email, inbox, push, chat, or any channel id.
/// </summary>
[JsonConverter(typeof(ContentConverter))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(ElementalContentSugar value) =>
        new ContentVariants::ElementalContentSugar(value);

    public static implicit operator Content(ElementalContent value) =>
        new ContentVariants::ElementalContent(value);

    public bool TryPickElementalContentSugar([NotNullWhen(true)] out ElementalContentSugar? value)
    {
        value = (this as ContentVariants::ElementalContentSugar)?.Value;
        return value != null;
    }

    public bool TryPickElemental([NotNullWhen(true)] out ElementalContent? value)
    {
        value = (this as ContentVariants::ElementalContent)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ContentVariants::ElementalContentSugar> elementalContentSugar,
        Action<ContentVariants::ElementalContent> elemental
    )
    {
        switch (this)
        {
            case ContentVariants::ElementalContentSugar inner:
                elementalContentSugar(inner);
                break;
            case ContentVariants::ElementalContent inner:
                elemental(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Content");
        }
    }

    public T Match<T>(
        Func<ContentVariants::ElementalContentSugar, T> elementalContentSugar,
        Func<ContentVariants::ElementalContent, T> elemental
    )
    {
        return this switch
        {
            ContentVariants::ElementalContentSugar inner => elementalContentSugar(inner),
            ContentVariants::ElementalContent inner => elemental(inner),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Content"),
        };
    }

    public abstract void Validate();
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
                return new ContentVariants::ElementalContentSugar(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ContentVariants::ElementalContentSugar",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalContent>(ref reader, options);
            if (deserialized != null)
            {
                return new ContentVariants::ElementalContent(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ContentVariants::ElementalContent",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ContentVariants::ElementalContentSugar(var elementalContentSugar) =>
                elementalContentSugar,
            ContentVariants::ElementalContent(var elemental) => elemental,
            _ => throw new CourierInvalidDataException("Data did not match any variant of Content"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
