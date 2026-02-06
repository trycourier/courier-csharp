using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
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
public record class ElementalNode : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public ElementalNode(ElementalTextNodeWithType value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ElementalNode(ElementalMetaNodeWithType value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ElementalNode(ElementalChannelNodeWithType value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ElementalNode(ElementalImageNodeWithType value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ElementalNode(ElementalActionNodeWithType value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ElementalNode(ElementalDividerNodeWithType value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ElementalNode(ElementalQuoteNodeWithType value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ElementalNode(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ElementalTextNodeWithType"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextNodeWithType(out var value)) {
    ///     // `value` is of type `ElementalTextNodeWithType`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextNodeWithType([NotNullWhen(true)] out ElementalTextNodeWithType? value)
    {
        value = this.Value as ElementalTextNodeWithType;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ElementalMetaNodeWithType"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMetaNodeWithType(out var value)) {
    ///     // `value` is of type `ElementalMetaNodeWithType`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMetaNodeWithType([NotNullWhen(true)] out ElementalMetaNodeWithType? value)
    {
        value = this.Value as ElementalMetaNodeWithType;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ElementalChannelNodeWithType"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChannelNodeWithType(out var value)) {
    ///     // `value` is of type `ElementalChannelNodeWithType`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChannelNodeWithType(
        [NotNullWhen(true)] out ElementalChannelNodeWithType? value
    )
    {
        value = this.Value as ElementalChannelNodeWithType;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ElementalImageNodeWithType"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickImageNodeWithType(out var value)) {
    ///     // `value` is of type `ElementalImageNodeWithType`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickImageNodeWithType([NotNullWhen(true)] out ElementalImageNodeWithType? value)
    {
        value = this.Value as ElementalImageNodeWithType;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ElementalActionNodeWithType"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickActionNodeWithType(out var value)) {
    ///     // `value` is of type `ElementalActionNodeWithType`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickActionNodeWithType(
        [NotNullWhen(true)] out ElementalActionNodeWithType? value
    )
    {
        value = this.Value as ElementalActionNodeWithType;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ElementalDividerNodeWithType"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDividerNodeWithType(out var value)) {
    ///     // `value` is of type `ElementalDividerNodeWithType`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDividerNodeWithType(
        [NotNullWhen(true)] out ElementalDividerNodeWithType? value
    )
    {
        value = this.Value as ElementalDividerNodeWithType;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ElementalQuoteNodeWithType"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickQuoteNodeWithType(out var value)) {
    ///     // `value` is of type `ElementalQuoteNodeWithType`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickQuoteNodeWithType([NotNullWhen(true)] out ElementalQuoteNodeWithType? value)
    {
        value = this.Value as ElementalQuoteNodeWithType;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="CourierInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (ElementalTextNodeWithType value) => {...},
    ///     (ElementalMetaNodeWithType value) => {...},
    ///     (ElementalChannelNodeWithType value) => {...},
    ///     (ElementalImageNodeWithType value) => {...},
    ///     (ElementalActionNodeWithType value) => {...},
    ///     (ElementalDividerNodeWithType value) => {...},
    ///     (ElementalQuoteNodeWithType value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="CourierInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (ElementalTextNodeWithType value) => {...},
    ///     (ElementalMetaNodeWithType value) => {...},
    ///     (ElementalChannelNodeWithType value) => {...},
    ///     (ElementalImageNodeWithType value) => {...},
    ///     (ElementalActionNodeWithType value) => {...},
    ///     (ElementalDividerNodeWithType value) => {...},
    ///     (ElementalQuoteNodeWithType value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="CourierInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new CourierInvalidDataException(
                "Data did not match any variant of ElementalNode"
            );
        }
        this.Switch(
            (textNodeWithType) => textNodeWithType.Validate(),
            (metaNodeWithType) => metaNodeWithType.Validate(),
            (channelNodeWithType) => channelNodeWithType.Validate(),
            (imageNodeWithType) => imageNodeWithType.Validate(),
            (actionNodeWithType) => actionNodeWithType.Validate(),
            (dividerNodeWithType) => dividerNodeWithType.Validate(),
            (quoteNodeWithType) => quoteNodeWithType.Validate()
        );
    }

    public virtual bool Equals(ElementalNode? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            ElementalTextNodeWithType _ => 0,
            ElementalMetaNodeWithType _ => 1,
            ElementalChannelNodeWithType _ => 2,
            ElementalImageNodeWithType _ => 3,
            ElementalActionNodeWithType _ => 4,
            ElementalDividerNodeWithType _ => 5,
            ElementalQuoteNodeWithType _ => 6,
            _ => -1,
        };
    }
}

sealed class ElementalNodeConverter : JsonConverter<ElementalNode>
{
    public override ElementalNode? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalTextNodeWithType>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalMetaNodeWithType>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalChannelNodeWithType>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalImageNodeWithType>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalActionNodeWithType>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalDividerNodeWithType>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalQuoteNodeWithType>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ElementalNode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
