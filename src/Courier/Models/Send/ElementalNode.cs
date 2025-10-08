using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Send.ElementalNodeProperties;

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
public record class ElementalNode
{
    public object Value { get; private init; }

    public List<string>? Channels
    {
        get
        {
            return Match<List<string>?>(
                unionMember0: (x) => x.Channels,
                unionMember1: (x) => x.Channels,
                unionMember2: (x) => x.Channels,
                unionMember3: (x) => x.Channels,
                unionMember4: (_) => null,
                unionMember5: (x) => x.Channels,
                unionMember6: (x) => x.Channels
            );
        }
    }

    public string? If
    {
        get
        {
            return Match<string?>(
                unionMember0: (x) => x.If,
                unionMember1: (x) => x.If,
                unionMember2: (x) => x.If,
                unionMember3: (x) => x.If,
                unionMember4: (_) => null,
                unionMember5: (x) => x.If,
                unionMember6: (x) => x.If
            );
        }
    }

    public string? Loop
    {
        get
        {
            return Match<string?>(
                unionMember0: (x) => x.Loop,
                unionMember1: (x) => x.Loop,
                unionMember2: (x) => x.Loop,
                unionMember3: (x) => x.Loop,
                unionMember4: (_) => null,
                unionMember5: (x) => x.Loop,
                unionMember6: (x) => x.Loop
            );
        }
    }

    public string? Ref
    {
        get
        {
            return Match<string?>(
                unionMember0: (x) => x.Ref,
                unionMember1: (x) => x.Ref,
                unionMember2: (x) => x.Ref,
                unionMember3: (x) => x.Ref,
                unionMember4: (_) => null,
                unionMember5: (x) => x.Ref,
                unionMember6: (x) => x.Ref
            );
        }
    }

    public ElementalNode(UnionMember0 value)
    {
        Value = value;
    }

    public ElementalNode(UnionMember1 value)
    {
        Value = value;
    }

    public ElementalNode(UnionMember2 value)
    {
        Value = value;
    }

    public ElementalNode(UnionMember3 value)
    {
        Value = value;
    }

    public ElementalNode(UnionMember4 value)
    {
        Value = value;
    }

    public ElementalNode(UnionMember5 value)
    {
        Value = value;
    }

    public ElementalNode(UnionMember6 value)
    {
        Value = value;
    }

    ElementalNode(UnknownVariant value)
    {
        Value = value;
    }

    public static ElementalNode CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnionMember0([NotNullWhen(true)] out UnionMember0? value)
    {
        value = this.Value as UnionMember0;
        return value != null;
    }

    public bool TryPickUnionMember1([NotNullWhen(true)] out UnionMember1? value)
    {
        value = this.Value as UnionMember1;
        return value != null;
    }

    public bool TryPickUnionMember2([NotNullWhen(true)] out UnionMember2? value)
    {
        value = this.Value as UnionMember2;
        return value != null;
    }

    public bool TryPickUnionMember3([NotNullWhen(true)] out UnionMember3? value)
    {
        value = this.Value as UnionMember3;
        return value != null;
    }

    public bool TryPickUnionMember4([NotNullWhen(true)] out UnionMember4? value)
    {
        value = this.Value as UnionMember4;
        return value != null;
    }

    public bool TryPickUnionMember5([NotNullWhen(true)] out UnionMember5? value)
    {
        value = this.Value as UnionMember5;
        return value != null;
    }

    public bool TryPickUnionMember6([NotNullWhen(true)] out UnionMember6? value)
    {
        value = this.Value as UnionMember6;
        return value != null;
    }

    public void Switch(
        Action<UnionMember0> unionMember0,
        Action<UnionMember1> unionMember1,
        Action<UnionMember2> unionMember2,
        Action<UnionMember3> unionMember3,
        Action<UnionMember4> unionMember4,
        Action<UnionMember5> unionMember5,
        Action<UnionMember6> unionMember6
    )
    {
        switch (this.Value)
        {
            case UnionMember0 value:
                unionMember0(value);
                break;
            case UnionMember1 value:
                unionMember1(value);
                break;
            case UnionMember2 value:
                unionMember2(value);
                break;
            case UnionMember3 value:
                unionMember3(value);
                break;
            case UnionMember4 value:
                unionMember4(value);
                break;
            case UnionMember5 value:
                unionMember5(value);
                break;
            case UnionMember6 value:
                unionMember6(value);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of ElementalNode"
                );
        }
    }

    public T Match<T>(
        Func<UnionMember0, T> unionMember0,
        Func<UnionMember1, T> unionMember1,
        Func<UnionMember2, T> unionMember2,
        Func<UnionMember3, T> unionMember3,
        Func<UnionMember4, T> unionMember4,
        Func<UnionMember5, T> unionMember5,
        Func<UnionMember6, T> unionMember6
    )
    {
        return this.Value switch
        {
            UnionMember0 value => unionMember0(value),
            UnionMember1 value => unionMember1(value),
            UnionMember2 value => unionMember2(value),
            UnionMember3 value => unionMember3(value),
            UnionMember4 value => unionMember4(value),
            UnionMember5 value => unionMember5(value),
            UnionMember6 value => unionMember6(value),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of ElementalNode"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new CourierInvalidDataException(
                "Data did not match any variant of ElementalNode"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                deserialized.Validate();
                return new ElementalNode(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'UnionMember0'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember1>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new ElementalNode(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'UnionMember1'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember2>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new ElementalNode(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'UnionMember2'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember3>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new ElementalNode(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'UnionMember3'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember4>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new ElementalNode(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'UnionMember4'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember5>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new ElementalNode(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'UnionMember5'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember6>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new ElementalNode(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'UnionMember6'",
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
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
