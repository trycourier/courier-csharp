using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Send.ContentProperties.ElementalContentProperties.ElementProperties;
using ElementVariants = Courier.Models.Send.ContentProperties.ElementalContentProperties.ElementVariants;

namespace Courier.Models.Send.ContentProperties.ElementalContentProperties;

[JsonConverter(typeof(ElementConverter))]
public abstract record class Element
{
    internal Element() { }

    public static implicit operator Element(UnionMember0 value) =>
        new ElementVariants::UnionMember0(value);

    public static implicit operator Element(UnionMember1 value) =>
        new ElementVariants::UnionMember1(value);

    public static implicit operator Element(UnionMember2 value) =>
        new ElementVariants::UnionMember2(value);

    public static implicit operator Element(UnionMember3 value) =>
        new ElementVariants::UnionMember3(value);

    public static implicit operator Element(UnionMember4 value) =>
        new ElementVariants::UnionMember4(value);

    public static implicit operator Element(UnionMember5 value) =>
        new ElementVariants::UnionMember5(value);

    public bool TryPickUnionMember0([NotNullWhen(true)] out UnionMember0? value)
    {
        value = (this as ElementVariants::UnionMember0)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember1([NotNullWhen(true)] out UnionMember1? value)
    {
        value = (this as ElementVariants::UnionMember1)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember2([NotNullWhen(true)] out UnionMember2? value)
    {
        value = (this as ElementVariants::UnionMember2)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember3([NotNullWhen(true)] out UnionMember3? value)
    {
        value = (this as ElementVariants::UnionMember3)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember4([NotNullWhen(true)] out UnionMember4? value)
    {
        value = (this as ElementVariants::UnionMember4)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember5([NotNullWhen(true)] out UnionMember5? value)
    {
        value = (this as ElementVariants::UnionMember5)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ElementVariants::UnionMember0> unionMember0,
        Action<ElementVariants::UnionMember1> unionMember1,
        Action<ElementVariants::UnionMember2> unionMember2,
        Action<ElementVariants::UnionMember3> unionMember3,
        Action<ElementVariants::UnionMember4> unionMember4,
        Action<ElementVariants::UnionMember5> unionMember5
    )
    {
        switch (this)
        {
            case ElementVariants::UnionMember0 inner:
                unionMember0(inner);
                break;
            case ElementVariants::UnionMember1 inner:
                unionMember1(inner);
                break;
            case ElementVariants::UnionMember2 inner:
                unionMember2(inner);
                break;
            case ElementVariants::UnionMember3 inner:
                unionMember3(inner);
                break;
            case ElementVariants::UnionMember4 inner:
                unionMember4(inner);
                break;
            case ElementVariants::UnionMember5 inner:
                unionMember5(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Element");
        }
    }

    public T Match<T>(
        Func<ElementVariants::UnionMember0, T> unionMember0,
        Func<ElementVariants::UnionMember1, T> unionMember1,
        Func<ElementVariants::UnionMember2, T> unionMember2,
        Func<ElementVariants::UnionMember3, T> unionMember3,
        Func<ElementVariants::UnionMember4, T> unionMember4,
        Func<ElementVariants::UnionMember5, T> unionMember5
    )
    {
        return this switch
        {
            ElementVariants::UnionMember0 inner => unionMember0(inner),
            ElementVariants::UnionMember1 inner => unionMember1(inner),
            ElementVariants::UnionMember2 inner => unionMember2(inner),
            ElementVariants::UnionMember3 inner => unionMember3(inner),
            ElementVariants::UnionMember4 inner => unionMember4(inner),
            ElementVariants::UnionMember5 inner => unionMember5(inner),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Element"),
        };
    }

    public abstract void Validate();
}

sealed class ElementConverter : JsonConverter<Element>
{
    public override Element? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember0>(ref reader, options);
            if (deserialized != null)
            {
                return new ElementVariants::UnionMember0(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ElementVariants::UnionMember0",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember1>(ref reader, options);
            if (deserialized != null)
            {
                return new ElementVariants::UnionMember1(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ElementVariants::UnionMember1",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember2>(ref reader, options);
            if (deserialized != null)
            {
                return new ElementVariants::UnionMember2(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ElementVariants::UnionMember2",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember3>(ref reader, options);
            if (deserialized != null)
            {
                return new ElementVariants::UnionMember3(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ElementVariants::UnionMember3",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember4>(ref reader, options);
            if (deserialized != null)
            {
                return new ElementVariants::UnionMember4(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ElementVariants::UnionMember4",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember5>(ref reader, options);
            if (deserialized != null)
            {
                return new ElementVariants::UnionMember5(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ElementVariants::UnionMember5",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Element value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ElementVariants::UnionMember0(var unionMember0) => unionMember0,
            ElementVariants::UnionMember1(var unionMember1) => unionMember1,
            ElementVariants::UnionMember2(var unionMember2) => unionMember2,
            ElementVariants::UnionMember3(var unionMember3) => unionMember3,
            ElementVariants::UnionMember4(var unionMember4) => unionMember4,
            ElementVariants::UnionMember5(var unionMember5) => unionMember5,
            _ => throw new CourierInvalidDataException("Data did not match any variant of Element"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
