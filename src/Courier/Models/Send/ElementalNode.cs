using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Send.ElementalNodeProperties;
using ElementalNodeVariants = Courier.Models.Send.ElementalNodeVariants;

namespace Courier.Models.Send;

/// <summary>
/// The channel element allows a notification to be customized based on which channel
/// it is sent through.  For example, you may want to display a detailed message
/// when the notification is sent through email,  and a more concise message in a
/// push notification. Channel elements are only valid as top-level  elements; you
/// cannot nest channel elements. If there is a channel element specified at the
/// top-level  of the document, all sibling elements must be channel elements. Note:
/// As an alternative, most elements support a `channel` property. Which allows you
/// to selectively  display an individual element on a per channel basis. See the
///  [control flow docs](https://www.courier.com/docs/platform/content/elemental/control-flow/)
/// for more details.
/// </summary>
[JsonConverter(typeof(ElementalNodeConverter))]
public abstract record class ElementalNode
{
    internal ElementalNode() { }

    public static implicit operator ElementalNode(UnionMember0 value) =>
        new ElementalNodeVariants::UnionMember0(value);

    public static implicit operator ElementalNode(UnionMember1 value) =>
        new ElementalNodeVariants::UnionMember1(value);

    public static implicit operator ElementalNode(UnionMember2 value) =>
        new ElementalNodeVariants::UnionMember2(value);

    public static implicit operator ElementalNode(UnionMember3 value) =>
        new ElementalNodeVariants::UnionMember3(value);

    public static implicit operator ElementalNode(UnionMember4 value) =>
        new ElementalNodeVariants::UnionMember4(value);

    public static implicit operator ElementalNode(UnionMember5 value) =>
        new ElementalNodeVariants::UnionMember5(value);

    public static implicit operator ElementalNode(UnionMember6 value) =>
        new ElementalNodeVariants::UnionMember6(value);

    public static implicit operator ElementalNode(UnionMember7 value) =>
        new ElementalNodeVariants::UnionMember7(value);

    public bool TryPickUnionMember0([NotNullWhen(true)] out UnionMember0? value)
    {
        value = (this as ElementalNodeVariants::UnionMember0)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember1([NotNullWhen(true)] out UnionMember1? value)
    {
        value = (this as ElementalNodeVariants::UnionMember1)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember2([NotNullWhen(true)] out UnionMember2? value)
    {
        value = (this as ElementalNodeVariants::UnionMember2)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember3([NotNullWhen(true)] out UnionMember3? value)
    {
        value = (this as ElementalNodeVariants::UnionMember3)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember4([NotNullWhen(true)] out UnionMember4? value)
    {
        value = (this as ElementalNodeVariants::UnionMember4)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember5([NotNullWhen(true)] out UnionMember5? value)
    {
        value = (this as ElementalNodeVariants::UnionMember5)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember6([NotNullWhen(true)] out UnionMember6? value)
    {
        value = (this as ElementalNodeVariants::UnionMember6)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember7([NotNullWhen(true)] out UnionMember7? value)
    {
        value = (this as ElementalNodeVariants::UnionMember7)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ElementalNodeVariants::UnionMember0> unionMember0,
        Action<ElementalNodeVariants::UnionMember1> unionMember1,
        Action<ElementalNodeVariants::UnionMember2> unionMember2,
        Action<ElementalNodeVariants::UnionMember3> unionMember3,
        Action<ElementalNodeVariants::UnionMember4> unionMember4,
        Action<ElementalNodeVariants::UnionMember5> unionMember5,
        Action<ElementalNodeVariants::UnionMember6> unionMember6,
        Action<ElementalNodeVariants::UnionMember7> unionMember7
    )
    {
        switch (this)
        {
            case ElementalNodeVariants::UnionMember0 inner:
                unionMember0(inner);
                break;
            case ElementalNodeVariants::UnionMember1 inner:
                unionMember1(inner);
                break;
            case ElementalNodeVariants::UnionMember2 inner:
                unionMember2(inner);
                break;
            case ElementalNodeVariants::UnionMember3 inner:
                unionMember3(inner);
                break;
            case ElementalNodeVariants::UnionMember4 inner:
                unionMember4(inner);
                break;
            case ElementalNodeVariants::UnionMember5 inner:
                unionMember5(inner);
                break;
            case ElementalNodeVariants::UnionMember6 inner:
                unionMember6(inner);
                break;
            case ElementalNodeVariants::UnionMember7 inner:
                unionMember7(inner);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of ElementalNode"
                );
        }
    }

    public T Match<T>(
        Func<ElementalNodeVariants::UnionMember0, T> unionMember0,
        Func<ElementalNodeVariants::UnionMember1, T> unionMember1,
        Func<ElementalNodeVariants::UnionMember2, T> unionMember2,
        Func<ElementalNodeVariants::UnionMember3, T> unionMember3,
        Func<ElementalNodeVariants::UnionMember4, T> unionMember4,
        Func<ElementalNodeVariants::UnionMember5, T> unionMember5,
        Func<ElementalNodeVariants::UnionMember6, T> unionMember6,
        Func<ElementalNodeVariants::UnionMember7, T> unionMember7
    )
    {
        return this switch
        {
            ElementalNodeVariants::UnionMember0 inner => unionMember0(inner),
            ElementalNodeVariants::UnionMember1 inner => unionMember1(inner),
            ElementalNodeVariants::UnionMember2 inner => unionMember2(inner),
            ElementalNodeVariants::UnionMember3 inner => unionMember3(inner),
            ElementalNodeVariants::UnionMember4 inner => unionMember4(inner),
            ElementalNodeVariants::UnionMember5 inner => unionMember5(inner),
            ElementalNodeVariants::UnionMember6 inner => unionMember6(inner),
            ElementalNodeVariants::UnionMember7 inner => unionMember7(inner),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of ElementalNode"
            ),
        };
    }

    public abstract void Validate();
}

sealed class ElementalNodeConverter : JsonConverter<ElementalNode>
{
    public override ElementalNode? Read(
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
                return new ElementalNodeVariants::UnionMember0(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ElementalNodeVariants::UnionMember0",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember1>(ref reader, options);
            if (deserialized != null)
            {
                return new ElementalNodeVariants::UnionMember1(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ElementalNodeVariants::UnionMember1",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember2>(ref reader, options);
            if (deserialized != null)
            {
                return new ElementalNodeVariants::UnionMember2(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ElementalNodeVariants::UnionMember2",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember3>(ref reader, options);
            if (deserialized != null)
            {
                return new ElementalNodeVariants::UnionMember3(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ElementalNodeVariants::UnionMember3",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember4>(ref reader, options);
            if (deserialized != null)
            {
                return new ElementalNodeVariants::UnionMember4(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ElementalNodeVariants::UnionMember4",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember5>(ref reader, options);
            if (deserialized != null)
            {
                return new ElementalNodeVariants::UnionMember5(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ElementalNodeVariants::UnionMember5",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember6>(ref reader, options);
            if (deserialized != null)
            {
                return new ElementalNodeVariants::UnionMember6(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ElementalNodeVariants::UnionMember6",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember7>(ref reader, options);
            if (deserialized != null)
            {
                return new ElementalNodeVariants::UnionMember7(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ElementalNodeVariants::UnionMember7",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ElementalNode value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ElementalNodeVariants::UnionMember0(var unionMember0) => unionMember0,
            ElementalNodeVariants::UnionMember1(var unionMember1) => unionMember1,
            ElementalNodeVariants::UnionMember2(var unionMember2) => unionMember2,
            ElementalNodeVariants::UnionMember3(var unionMember3) => unionMember3,
            ElementalNodeVariants::UnionMember4(var unionMember4) => unionMember4,
            ElementalNodeVariants::UnionMember5(var unionMember5) => unionMember5,
            ElementalNodeVariants::UnionMember6(var unionMember6) => unionMember6,
            ElementalNodeVariants::UnionMember7(var unionMember7) => unionMember7,
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of ElementalNode"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
