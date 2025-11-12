using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

/// <summary>
/// The channel element allows a notification to be customized based on which channel
/// it is sent through.  For example, you may want to display a detailed message when
/// the notification is sent through email,  and a more concise message in a push
/// notification. Channel elements are only valid as top-level  elements; you cannot
/// nest channel elements. If there is a channel element specified at the top-level
///  of the document, all sibling elements must be channel elements. Note: As an alternative,
/// most elements support a `channel` property. Which allows you to selectively  display
/// an individual element on a per channel basis. See the  [control flow docs](https://www.courier.com/docs/platform/content/elemental/control-flow/)
/// for more details.
/// </summary>
[JsonConverter(typeof(ElementalNodeConverter))]
public record class ElementalNode
{
    public object Value { get; private init; }

    public IReadOnlyList<string>? Channels
    {
        get
        {
            return Match<IReadOnlyList<string>?>(
                textNodeWithType: (x) => x.Channels,
                metaNodeWithType: (x) => x.Channels,
                channelNodeWithType: (x) => x.Channels,
                imageNodeWithType: (x) => x.Channels,
                actionNodeWithType: (x) => x.Channels,
                dividerNodeWithType: (x) => x.Channels,
                quoteNodeWithType: (x) => x.Channels
            );
        }
    }

    public string? If
    {
        get
        {
            return Match<string?>(
                textNodeWithType: (x) => x.If,
                metaNodeWithType: (x) => x.If,
                channelNodeWithType: (x) => x.If,
                imageNodeWithType: (x) => x.If,
                actionNodeWithType: (x) => x.If,
                dividerNodeWithType: (x) => x.If,
                quoteNodeWithType: (x) => x.If
            );
        }
    }

    public string? Loop
    {
        get
        {
            return Match<string?>(
                textNodeWithType: (x) => x.Loop,
                metaNodeWithType: (x) => x.Loop,
                channelNodeWithType: (x) => x.Loop,
                imageNodeWithType: (x) => x.Loop,
                actionNodeWithType: (x) => x.Loop,
                dividerNodeWithType: (x) => x.Loop,
                quoteNodeWithType: (x) => x.Loop
            );
        }
    }

    public string? Ref
    {
        get
        {
            return Match<string?>(
                textNodeWithType: (x) => x.Ref,
                metaNodeWithType: (x) => x.Ref,
                channelNodeWithType: (x) => x.Ref,
                imageNodeWithType: (x) => x.Ref,
                actionNodeWithType: (x) => x.Ref,
                dividerNodeWithType: (x) => x.Ref,
                quoteNodeWithType: (x) => x.Ref
            );
        }
    }

    public ElementalNode(ElementalTextNodeWithType value)
    {
        Value = value;
    }

    public ElementalNode(ElementalMetaNodeWithType value)
    {
        Value = value;
    }

    public ElementalNode(ElementalChannelNodeWithType value)
    {
        Value = value;
    }

    public ElementalNode(ElementalImageNodeWithType value)
    {
        Value = value;
    }

    public ElementalNode(ElementalActionNodeWithType value)
    {
        Value = value;
    }

    public ElementalNode(ElementalDividerNodeWithType value)
    {
        Value = value;
    }

    public ElementalNode(ElementalQuoteNodeWithType value)
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

    public bool TryPickTextNodeWithType([NotNullWhen(true)] out ElementalTextNodeWithType? value)
    {
        value = this.Value as ElementalTextNodeWithType;
        return value != null;
    }

    public bool TryPickMetaNodeWithType([NotNullWhen(true)] out ElementalMetaNodeWithType? value)
    {
        value = this.Value as ElementalMetaNodeWithType;
        return value != null;
    }

    public bool TryPickChannelNodeWithType(
        [NotNullWhen(true)] out ElementalChannelNodeWithType? value
    )
    {
        value = this.Value as ElementalChannelNodeWithType;
        return value != null;
    }

    public bool TryPickImageNodeWithType([NotNullWhen(true)] out ElementalImageNodeWithType? value)
    {
        value = this.Value as ElementalImageNodeWithType;
        return value != null;
    }

    public bool TryPickActionNodeWithType(
        [NotNullWhen(true)] out ElementalActionNodeWithType? value
    )
    {
        value = this.Value as ElementalActionNodeWithType;
        return value != null;
    }

    public bool TryPickDividerNodeWithType(
        [NotNullWhen(true)] out ElementalDividerNodeWithType? value
    )
    {
        value = this.Value as ElementalDividerNodeWithType;
        return value != null;
    }

    public bool TryPickQuoteNodeWithType([NotNullWhen(true)] out ElementalQuoteNodeWithType? value)
    {
        value = this.Value as ElementalQuoteNodeWithType;
        return value != null;
    }

    public void Switch(
        System::Action<ElementalTextNodeWithType> textNodeWithType,
        System::Action<ElementalMetaNodeWithType> metaNodeWithType,
        System::Action<ElementalChannelNodeWithType> channelNodeWithType,
        System::Action<ElementalImageNodeWithType> imageNodeWithType,
        System::Action<ElementalActionNodeWithType> actionNodeWithType,
        System::Action<ElementalDividerNodeWithType> dividerNodeWithType,
        System::Action<ElementalQuoteNodeWithType> quoteNodeWithType
    )
    {
        switch (this.Value)
        {
            case ElementalTextNodeWithType value:
                textNodeWithType(value);
                break;
            case ElementalMetaNodeWithType value:
                metaNodeWithType(value);
                break;
            case ElementalChannelNodeWithType value:
                channelNodeWithType(value);
                break;
            case ElementalImageNodeWithType value:
                imageNodeWithType(value);
                break;
            case ElementalActionNodeWithType value:
                actionNodeWithType(value);
                break;
            case ElementalDividerNodeWithType value:
                dividerNodeWithType(value);
                break;
            case ElementalQuoteNodeWithType value:
                quoteNodeWithType(value);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of ElementalNode"
                );
        }
    }

    public T Match<T>(
        System::Func<ElementalTextNodeWithType, T> textNodeWithType,
        System::Func<ElementalMetaNodeWithType, T> metaNodeWithType,
        System::Func<ElementalChannelNodeWithType, T> channelNodeWithType,
        System::Func<ElementalImageNodeWithType, T> imageNodeWithType,
        System::Func<ElementalActionNodeWithType, T> actionNodeWithType,
        System::Func<ElementalDividerNodeWithType, T> dividerNodeWithType,
        System::Func<ElementalQuoteNodeWithType, T> quoteNodeWithType
    )
    {
        return this.Value switch
        {
            ElementalTextNodeWithType value => textNodeWithType(value),
            ElementalMetaNodeWithType value => metaNodeWithType(value),
            ElementalChannelNodeWithType value => channelNodeWithType(value),
            ElementalImageNodeWithType value => imageNodeWithType(value),
            ElementalActionNodeWithType value => actionNodeWithType(value),
            ElementalDividerNodeWithType value => dividerNodeWithType(value),
            ElementalQuoteNodeWithType value => quoteNodeWithType(value),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of ElementalNode"
            ),
        };
    }

    public static implicit operator ElementalNode(ElementalTextNodeWithType value) => new(value);

    public static implicit operator ElementalNode(ElementalMetaNodeWithType value) => new(value);

    public static implicit operator ElementalNode(ElementalChannelNodeWithType value) => new(value);

    public static implicit operator ElementalNode(ElementalImageNodeWithType value) => new(value);

    public static implicit operator ElementalNode(ElementalActionNodeWithType value) => new(value);

    public static implicit operator ElementalNode(ElementalDividerNodeWithType value) => new(value);

    public static implicit operator ElementalNode(ElementalQuoteNodeWithType value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new CourierInvalidDataException(
                "Data did not match any variant of ElementalNode"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ElementalNodeConverter : JsonConverter<ElementalNode>
{
    public override ElementalNode? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalTextNodeWithType>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new ElementalNode(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'ElementalTextNodeWithType'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalMetaNodeWithType>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new ElementalNode(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'ElementalMetaNodeWithType'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalChannelNodeWithType>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new ElementalNode(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'ElementalChannelNodeWithType'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalImageNodeWithType>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new ElementalNode(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'ElementalImageNodeWithType'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalActionNodeWithType>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new ElementalNode(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'ElementalActionNodeWithType'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalDividerNodeWithType>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new ElementalNode(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'ElementalDividerNodeWithType'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalQuoteNodeWithType>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new ElementalNode(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'ElementalQuoteNodeWithType'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
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
