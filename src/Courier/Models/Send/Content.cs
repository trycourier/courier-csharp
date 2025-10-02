using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Send.ContentProperties;
using Courier.Models.Tenants.Templates;
using ContentVariants = Courier.Models.Send.ContentVariants;

namespace Courier.Models.Send;

/// <summary>
/// Syntatic Sugar to provide a fast shorthand for Courier Elemental Blocks.
/// </summary>
[JsonConverter(typeof(ContentConverter))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(ElementalContent value) =>
        new ContentVariants::ElementalContent(value);

    public static implicit operator Content(ElementalContentSugar value) =>
        new ContentVariants::ElementalContentSugar(value);

    public bool TryPickElemental([NotNullWhen(true)] out ElementalContent? value)
    {
        value = (this as ContentVariants::ElementalContent)?.Value;
        return value != null;
    }

    public bool TryPickElementalContentSugar([NotNullWhen(true)] out ElementalContentSugar? value)
    {
        value = (this as ContentVariants::ElementalContentSugar)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ContentVariants::ElementalContent> elemental,
        Action<ContentVariants::ElementalContentSugar> elementalContentSugar
    )
    {
        switch (this)
        {
            case ContentVariants::ElementalContent inner:
                elemental(inner);
                break;
            case ContentVariants::ElementalContentSugar inner:
                elementalContentSugar(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Content");
        }
    }

    public T Match<T>(
        Func<ContentVariants::ElementalContent, T> elemental,
        Func<ContentVariants::ElementalContentSugar, T> elementalContentSugar
    )
    {
        return this switch
        {
            ContentVariants::ElementalContent inner => elemental(inner),
            ContentVariants::ElementalContentSugar inner => elementalContentSugar(inner),
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

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ContentVariants::ElementalContent(var elemental) => elemental,
            ContentVariants::ElementalContentSugar(var elementalContentSugar) =>
                elementalContentSugar,
            _ => throw new CourierInvalidDataException("Data did not match any variant of Content"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
