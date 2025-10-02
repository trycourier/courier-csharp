using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using ElementProperties = Courier.Models.Send.ContentProperties.ElementalContentProperties.ElementProperties;
using ElementVariants = Courier.Models.Send.ContentProperties.ElementalContentProperties.ElementVariants;

namespace Courier.Models.Send.ContentProperties.ElementalContentProperties;

[JsonConverter(typeof(ElementConverter))]
public abstract record class Element
{
    internal Element() { }

    public static implicit operator Element(ElementProperties::UnionMember0 value) =>
        new ElementVariants::UnionMember0(value);

    public static implicit operator Element(ElementProperties::UnionMember1 value) =>
        new ElementVariants::UnionMember1(value);

    public static implicit operator Element(ElementProperties::Type value) =>
        new ElementVariants::Type(value);

    public static implicit operator Element(ElementProperties::UnionMember3 value) =>
        new ElementVariants::UnionMember3(value);

    public static implicit operator Element(ElementProperties::UnionMember4 value) =>
        new ElementVariants::UnionMember4(value);

    public static implicit operator Element(ElementProperties::UnionMember5 value) =>
        new ElementVariants::UnionMember5(value);

    public static implicit operator Element(ElementProperties::TypeModel value) =>
        new ElementVariants::TypeModel(value);

    public static implicit operator Element(ElementProperties::UnionMember7 value) =>
        new ElementVariants::UnionMember7(value);

    public bool TryPickUnionMember0([NotNullWhen(true)] out ElementProperties::UnionMember0? value)
    {
        value = (this as ElementVariants::UnionMember0)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember1([NotNullWhen(true)] out ElementProperties::UnionMember1? value)
    {
        value = (this as ElementVariants::UnionMember1)?.Value;
        return value != null;
    }

    public bool TryPickType([NotNullWhen(true)] out ElementProperties::Type? value)
    {
        value = (this as ElementVariants::Type)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember3([NotNullWhen(true)] out ElementProperties::UnionMember3? value)
    {
        value = (this as ElementVariants::UnionMember3)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember4([NotNullWhen(true)] out ElementProperties::UnionMember4? value)
    {
        value = (this as ElementVariants::UnionMember4)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember5([NotNullWhen(true)] out ElementProperties::UnionMember5? value)
    {
        value = (this as ElementVariants::UnionMember5)?.Value;
        return value != null;
    }

    public bool TryPickTypeModel([NotNullWhen(true)] out ElementProperties::TypeModel? value)
    {
        value = (this as ElementVariants::TypeModel)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember7([NotNullWhen(true)] out ElementProperties::UnionMember7? value)
    {
        value = (this as ElementVariants::UnionMember7)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ElementVariants::UnionMember0> unionMember0,
        Action<ElementVariants::UnionMember1> unionMember1,
        Action<ElementVariants::Type> type,
        Action<ElementVariants::UnionMember3> unionMember3,
        Action<ElementVariants::UnionMember4> unionMember4,
        Action<ElementVariants::UnionMember5> unionMember5,
        Action<ElementVariants::TypeModel> typeModel,
        Action<ElementVariants::UnionMember7> unionMember7
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
            case ElementVariants::Type inner:
                type(inner);
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
            case ElementVariants::TypeModel inner:
                typeModel(inner);
                break;
            case ElementVariants::UnionMember7 inner:
                unionMember7(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Element");
        }
    }

    public T Match<T>(
        Func<ElementVariants::UnionMember0, T> unionMember0,
        Func<ElementVariants::UnionMember1, T> unionMember1,
        Func<ElementVariants::Type, T> type,
        Func<ElementVariants::UnionMember3, T> unionMember3,
        Func<ElementVariants::UnionMember4, T> unionMember4,
        Func<ElementVariants::UnionMember5, T> unionMember5,
        Func<ElementVariants::TypeModel, T> typeModel,
        Func<ElementVariants::UnionMember7, T> unionMember7
    )
    {
        return this switch
        {
            ElementVariants::UnionMember0 inner => unionMember0(inner),
            ElementVariants::UnionMember1 inner => unionMember1(inner),
            ElementVariants::Type inner => type(inner),
            ElementVariants::UnionMember3 inner => unionMember3(inner),
            ElementVariants::UnionMember4 inner => unionMember4(inner),
            ElementVariants::UnionMember5 inner => unionMember5(inner),
            ElementVariants::TypeModel inner => typeModel(inner),
            ElementVariants::UnionMember7 inner => unionMember7(inner),
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
            var deserialized = JsonSerializer.Deserialize<ElementProperties::UnionMember0>(
                ref reader,
                options
            );
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
            var deserialized = JsonSerializer.Deserialize<ElementProperties::UnionMember1>(
                ref reader,
                options
            );
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
            var deserialized = JsonSerializer.Deserialize<ElementProperties::Type>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ElementVariants::Type(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ElementVariants::Type",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementProperties::UnionMember3>(
                ref reader,
                options
            );
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
            var deserialized = JsonSerializer.Deserialize<ElementProperties::UnionMember4>(
                ref reader,
                options
            );
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
            var deserialized = JsonSerializer.Deserialize<ElementProperties::UnionMember5>(
                ref reader,
                options
            );
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

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementProperties::TypeModel>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ElementVariants::TypeModel(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ElementVariants::TypeModel",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementProperties::UnionMember7>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ElementVariants::UnionMember7(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ElementVariants::UnionMember7",
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
            ElementVariants::Type(var type) => type,
            ElementVariants::UnionMember3(var unionMember3) => unionMember3,
            ElementVariants::UnionMember4(var unionMember4) => unionMember4,
            ElementVariants::UnionMember5(var unionMember5) => unionMember5,
            ElementVariants::TypeModel(var typeModel) => typeModel,
            ElementVariants::UnionMember7(var unionMember7) => unionMember7,
            _ => throw new CourierInvalidDataException("Data did not match any variant of Element"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
