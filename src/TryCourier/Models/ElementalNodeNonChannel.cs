using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models;

/// <summary>
/// Any Elemental node except a channel block. Channel elements are only valid as
/// top-level elements, so the `elements` nested inside one can never be another channel.
/// Keeping this union channel-free also keeps the schema acyclic; a recursive `$ref`
/// here breaks the generated Python models.
/// </summary>
[JsonConverter(typeof(ElementalNodeNonChannelConverter))]
public record class ElementalNodeNonChannel : ModelBase
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
                unionMember0: (x) => x.Channels,
                unionMember1: (x) => x.Channels,
                unionMember2: (x) => x.Channels,
                unionMember3: (x) => x.Channels,
                unionMember4: (x) => x.Channels,
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
                unionMember4: (x) => x.If,
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
                unionMember4: (x) => x.Loop,
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
                unionMember4: (x) => x.Ref,
                unionMember5: (x) => x.Ref,
                unionMember6: (x) => x.Ref
            );
        }
    }

    public string? Color
    {
        get
        {
            return Match<string?>(
                unionMember0: (x) => x.Color,
                unionMember1: (_) => null,
                unionMember2: (_) => null,
                unionMember3: (_) => null,
                unionMember4: (x) => x.Color,
                unionMember5: (_) => null,
                unionMember6: (_) => null
            );
        }
    }

    public string? Content
    {
        get
        {
            return Match<string?>(
                unionMember0: (x) => x.Content,
                unionMember1: (_) => null,
                unionMember2: (_) => null,
                unionMember3: (x) => x.Content,
                unionMember4: (_) => null,
                unionMember5: (x) => x.Content,
                unionMember6: (x) => x.Content
            );
        }
    }

    public string? FontSize
    {
        get
        {
            return Match<string?>(
                unionMember0: (x) => x.FontSize,
                unionMember1: (_) => null,
                unionMember2: (_) => null,
                unionMember3: (x) => x.FontSize,
                unionMember4: (_) => null,
                unionMember5: (x) => x.FontSize,
                unionMember6: (_) => null
            );
        }
    }

    public string? LineHeight
    {
        get
        {
            return Match<string?>(
                unionMember0: (x) => x.LineHeight,
                unionMember1: (_) => null,
                unionMember2: (_) => null,
                unionMember3: (_) => null,
                unionMember4: (_) => null,
                unionMember5: (x) => x.LineHeight,
                unionMember6: (_) => null
            );
        }
    }

    public IReadOnlyDictionary<string, LocalesItem>? Locales
    {
        get
        {
            return Match<IReadOnlyDictionary<string, LocalesItem>?>(
                unionMember0: (x) => x.Locales,
                unionMember1: (_) => null,
                unionMember2: (_) => null,
                unionMember3: (x) => x.Locales,
                unionMember4: (_) => null,
                unionMember5: (x) => x.Locales,
                unionMember6: (x) => x.Locales
            );
        }
    }

    public ApiEnum<string, TextStyle>? TextStyle
    {
        get
        {
            return Match<ApiEnum<string, TextStyle>?>(
                unionMember0: (x) => x.TextStyle,
                unionMember1: (_) => null,
                unionMember2: (_) => null,
                unionMember3: (_) => null,
                unionMember4: (_) => null,
                unionMember5: (x) => x.TextStyle,
                unionMember6: (_) => null
            );
        }
    }

    public string? BorderColor
    {
        get
        {
            return Match<string?>(
                unionMember0: (_) => null,
                unionMember1: (_) => null,
                unionMember2: (x) => x.BorderColor,
                unionMember3: (_) => null,
                unionMember4: (_) => null,
                unionMember5: (x) => x.BorderColor,
                unionMember6: (_) => null
            );
        }
    }

    public string? BorderSize
    {
        get
        {
            return Match<string?>(
                unionMember0: (_) => null,
                unionMember1: (_) => null,
                unionMember2: (x) => x.BorderSize,
                unionMember3: (x) => x.BorderSize,
                unionMember4: (_) => null,
                unionMember5: (_) => null,
                unionMember6: (_) => null
            );
        }
    }

    public string? Href
    {
        get
        {
            return Match<string?>(
                unionMember0: (_) => null,
                unionMember1: (_) => null,
                unionMember2: (x) => x.Href,
                unionMember3: (x) => x.Href,
                unionMember4: (_) => null,
                unionMember5: (_) => null,
                unionMember6: (_) => null
            );
        }
    }

    public string? Padding
    {
        get
        {
            return Match<string?>(
                unionMember0: (_) => null,
                unionMember1: (_) => null,
                unionMember2: (x) => x.Padding,
                unionMember3: (x) => x.Padding,
                unionMember4: (_) => null,
                unionMember5: (_) => null,
                unionMember6: (_) => null
            );
        }
    }

    public ElementalNodeNonChannel(UnionMember0 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ElementalNodeNonChannel(UnionMember1 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ElementalNodeNonChannel(UnionMember2 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ElementalNodeNonChannel(UnionMember3 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ElementalNodeNonChannel(UnionMember4 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ElementalNodeNonChannel(UnionMember5 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ElementalNodeNonChannel(UnionMember6 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ElementalNodeNonChannel(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionMember0"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember0(out var value)) {
    ///     // `value` is of type `UnionMember0`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember0([NotNullWhen(true)] out UnionMember0? value)
    {
        value = this.Value as UnionMember0;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionMember1"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember1(out var value)) {
    ///     // `value` is of type `UnionMember1`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember1([NotNullWhen(true)] out UnionMember1? value)
    {
        value = this.Value as UnionMember1;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionMember2"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember2(out var value)) {
    ///     // `value` is of type `UnionMember2`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember2([NotNullWhen(true)] out UnionMember2? value)
    {
        value = this.Value as UnionMember2;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionMember3"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember3(out var value)) {
    ///     // `value` is of type `UnionMember3`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember3([NotNullWhen(true)] out UnionMember3? value)
    {
        value = this.Value as UnionMember3;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionMember4"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember4(out var value)) {
    ///     // `value` is of type `UnionMember4`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember4([NotNullWhen(true)] out UnionMember4? value)
    {
        value = this.Value as UnionMember4;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionMember5"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember5(out var value)) {
    ///     // `value` is of type `UnionMember5`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember5([NotNullWhen(true)] out UnionMember5? value)
    {
        value = this.Value as UnionMember5;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionMember6"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember6(out var value)) {
    ///     // `value` is of type `UnionMember6`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember6([NotNullWhen(true)] out UnionMember6? value)
    {
        value = this.Value as UnionMember6;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (UnionMember0 value) =&gt; {...},
    ///     (UnionMember1 value) =&gt; {...},
    ///     (UnionMember2 value) =&gt; {...},
    ///     (UnionMember3 value) =&gt; {...},
    ///     (UnionMember4 value) =&gt; {...},
    ///     (UnionMember5 value) =&gt; {...},
    ///     (UnionMember6 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<UnionMember0> unionMember0,
        System::Action<UnionMember1> unionMember1,
        System::Action<UnionMember2> unionMember2,
        System::Action<UnionMember3> unionMember3,
        System::Action<UnionMember4> unionMember4,
        System::Action<UnionMember5> unionMember5,
        System::Action<UnionMember6> unionMember6
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
                    "Data did not match any variant of ElementalNodeNonChannel"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (UnionMember0 value) =&gt; {...},
    ///     (UnionMember1 value) =&gt; {...},
    ///     (UnionMember2 value) =&gt; {...},
    ///     (UnionMember3 value) =&gt; {...},
    ///     (UnionMember4 value) =&gt; {...},
    ///     (UnionMember5 value) =&gt; {...},
    ///     (UnionMember6 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<UnionMember0, T> unionMember0,
        System::Func<UnionMember1, T> unionMember1,
        System::Func<UnionMember2, T> unionMember2,
        System::Func<UnionMember3, T> unionMember3,
        System::Func<UnionMember4, T> unionMember4,
        System::Func<UnionMember5, T> unionMember5,
        System::Func<UnionMember6, T> unionMember6
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
                "Data did not match any variant of ElementalNodeNonChannel"
            ),
        };
    }

    public static implicit operator ElementalNodeNonChannel(UnionMember0 value) => new(value);

    public static implicit operator ElementalNodeNonChannel(UnionMember1 value) => new(value);

    public static implicit operator ElementalNodeNonChannel(UnionMember2 value) => new(value);

    public static implicit operator ElementalNodeNonChannel(UnionMember3 value) => new(value);

    public static implicit operator ElementalNodeNonChannel(UnionMember4 value) => new(value);

    public static implicit operator ElementalNodeNonChannel(UnionMember5 value) => new(value);

    public static implicit operator ElementalNodeNonChannel(UnionMember6 value) => new(value);

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
                "Data did not match any variant of ElementalNodeNonChannel"
            );
        }
        this.Switch(
            (unionMember0) => unionMember0.Validate(),
            (unionMember1) => unionMember1.Validate(),
            (unionMember2) => unionMember2.Validate(),
            (unionMember3) => unionMember3.Validate(),
            (unionMember4) => unionMember4.Validate(),
            (unionMember5) => unionMember5.Validate(),
            (unionMember6) => unionMember6.Validate()
        );
    }

    public virtual bool Equals(ElementalNodeNonChannel? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            UnionMember0 _ => 0,
            UnionMember1 _ => 1,
            UnionMember2 _ => 2,
            UnionMember3 _ => 3,
            UnionMember4 _ => 4,
            UnionMember5 _ => 5,
            UnionMember6 _ => 6,
            _ => -1,
        };
    }
}

sealed class ElementalNodeNonChannelConverter : JsonConverter<ElementalNodeNonChannel>
{
    public override ElementalNodeNonChannel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember3>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<UnionMember2>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<UnionMember5>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<UnionMember6>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<UnionMember0>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<UnionMember1>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<UnionMember4>(element, options);
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
        ElementalNodeNonChannel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Represents a body of text to be rendered inside of the notification.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UnionMember0, UnionMember0FromRaw>))]
public sealed record class UnionMember0 : JsonModel
{
    public IReadOnlyList<string>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("channels");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "channels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? If
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("if");
        }
        init { this._rawData.Set("if", value); }
    }

    public string? Loop
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("loop");
        }
        init { this._rawData.Set("loop", value); }
    }

    public string? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ref");
        }
        init { this._rawData.Set("ref", value); }
    }

    /// <summary>
    /// Text alignment.
    /// </summary>
    public ApiEnum<string, Align>? Align
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Align>>("align");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("align", value);
        }
    }

    /// <summary>
    /// Apply bold to the text
    /// </summary>
    public string? Bold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bold");
        }
        init { this._rawData.Set("bold", value); }
    }

    /// <summary>
    /// Specifies the color of text. Can be any valid css color value
    /// </summary>
    public string? Color
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("color");
        }
        init { this._rawData.Set("color", value); }
    }

    /// <summary>
    /// The text content displayed in the notification. Either this field must be
    /// specified, or the elements field
    /// </summary>
    public string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("content", value);
        }
    }

    /// <summary>
    /// CSS px font size for this text block, e.g. `16px`. Overrides the size of
    /// the `text_style` preset. Email only.
    /// </summary>
    public string? FontSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("font_size");
        }
        init { this._rawData.Set("font_size", value); }
    }

    public ApiEnum<string, Format>? Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Format>>("format");
        }
        init { this._rawData.Set("format", value); }
    }

    /// <summary>
    /// Apply italics to the text
    /// </summary>
    public string? Italic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("italic");
        }
        init { this._rawData.Set("italic", value); }
    }

    /// <summary>
    /// CSS line height for this text block, as a px value or a unitless multiplier,
    /// e.g. `24px` or `1.5`. Email only.
    /// </summary>
    public string? LineHeight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line_height");
        }
        init { this._rawData.Set("line_height", value); }
    }

    /// <summary>
    /// Region specific content. See [locales docs](https://www.courier.com/docs/platform/content/elemental/locales/)
    /// for more details.
    /// </summary>
    public IReadOnlyDictionary<string, LocalesItem>? Locales
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, LocalesItem>>("locales");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, LocalesItem>?>(
                "locales",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Apply a strike through the text
    /// </summary>
    public string? Strikethrough
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("strikethrough");
        }
        init { this._rawData.Set("strikethrough", value); }
    }

    public ApiEnum<string, TextStyle>? TextStyle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TextStyle>>("text_style");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text_style", value);
        }
    }

    /// <summary>
    /// Apply an underline to the text
    /// </summary>
    public string? Underline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("underline");
        }
        init { this._rawData.Set("underline", value); }
    }

    public ApiEnum<string, UnionMember0IntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UnionMember0IntersectionMember1Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public static implicit operator ElementalTextNode(UnionMember0 unionMember0) =>
        new()
        {
            Channels = unionMember0.Channels,
            If = unionMember0.If,
            Loop = unionMember0.Loop,
            Ref = unionMember0.Ref,
            Align = unionMember0.Align,
            Bold = unionMember0.Bold,
            Color = unionMember0.Color,
            Content = unionMember0.Content,
            FontSize = unionMember0.FontSize,
            Format = unionMember0.Format,
            Italic = unionMember0.Italic,
            LineHeight = unionMember0.LineHeight,
            Locales = unionMember0.Locales,
            Strikethrough = unionMember0.Strikethrough,
            TextStyle = unionMember0.TextStyle,
            Underline = unionMember0.Underline,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channels;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        this.Align?.Validate();
        _ = this.Bold;
        _ = this.Color;
        _ = this.Content;
        _ = this.FontSize;
        this.Format?.Validate();
        _ = this.Italic;
        _ = this.LineHeight;
        if (this.Locales != null)
        {
            foreach (var item in this.Locales.Values)
            {
                item.Validate();
            }
        }
        _ = this.Strikethrough;
        this.TextStyle?.Validate();
        _ = this.Underline;
        this.Type?.Validate();
    }

    public UnionMember0() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember0(UnionMember0 unionMember0)
        : base(unionMember0) { }
#pragma warning restore CS8618

    public UnionMember0(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember0(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember0FromRaw.FromRawUnchecked"/>
    public static UnionMember0 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionMember0FromRaw : IFromRawJson<UnionMember0>
{
    /// <inheritdoc/>
    public UnionMember0 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionMember0.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnionMember0IntersectionMember1,
        UnionMember0IntersectionMember1FromRaw
    >)
)]
public sealed record class UnionMember0IntersectionMember1 : JsonModel
{
    public ApiEnum<string, UnionMember0IntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UnionMember0IntersectionMember1Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type?.Validate();
    }

    public UnionMember0IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember0IntersectionMember1(
        UnionMember0IntersectionMember1 unionMember0IntersectionMember1
    )
        : base(unionMember0IntersectionMember1) { }
#pragma warning restore CS8618

    public UnionMember0IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember0IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember0IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static UnionMember0IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionMember0IntersectionMember1FromRaw : IFromRawJson<UnionMember0IntersectionMember1>
{
    /// <inheritdoc/>
    public UnionMember0IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnionMember0IntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnionMember0IntersectionMember1TypeConverter))]
public enum UnionMember0IntersectionMember1Type
{
    Text,
}

sealed class UnionMember0IntersectionMember1TypeConverter
    : JsonConverter<UnionMember0IntersectionMember1Type>
{
    public override UnionMember0IntersectionMember1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => UnionMember0IntersectionMember1Type.Text,
            _ => (UnionMember0IntersectionMember1Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember0IntersectionMember1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionMember0IntersectionMember1Type.Text => "text",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The meta element contains information describing the notification that may  be
/// used by a particular channel or provider. One important field is the title  field
/// which will be used as the title for channels that support it.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UnionMember1, UnionMember1FromRaw>))]
public sealed record class UnionMember1 : JsonModel
{
    public IReadOnlyList<string>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("channels");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "channels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? If
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("if");
        }
        init { this._rawData.Set("if", value); }
    }

    public string? Loop
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("loop");
        }
        init { this._rawData.Set("loop", value); }
    }

    public string? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ref");
        }
        init { this._rawData.Set("ref", value); }
    }

    /// <summary>
    /// The title to be displayed by supported channels. For example, the email subject.
    /// </summary>
    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    public ApiEnum<string, UnionMember1IntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UnionMember1IntersectionMember1Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public static implicit operator ElementalMetaNode(UnionMember1 unionMember1) =>
        new()
        {
            Channels = unionMember1.Channels,
            If = unionMember1.If,
            Loop = unionMember1.Loop,
            Ref = unionMember1.Ref,
            Title = unionMember1.Title,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channels;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        _ = this.Title;
        this.Type?.Validate();
    }

    public UnionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember1(UnionMember1 unionMember1)
        : base(unionMember1) { }
#pragma warning restore CS8618

    public UnionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember1FromRaw.FromRawUnchecked"/>
    public static UnionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionMember1FromRaw : IFromRawJson<UnionMember1>
{
    /// <inheritdoc/>
    public UnionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnionMember1IntersectionMember1,
        UnionMember1IntersectionMember1FromRaw
    >)
)]
public sealed record class UnionMember1IntersectionMember1 : JsonModel
{
    public ApiEnum<string, UnionMember1IntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UnionMember1IntersectionMember1Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type?.Validate();
    }

    public UnionMember1IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember1IntersectionMember1(
        UnionMember1IntersectionMember1 unionMember1IntersectionMember1
    )
        : base(unionMember1IntersectionMember1) { }
#pragma warning restore CS8618

    public UnionMember1IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember1IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember1IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static UnionMember1IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionMember1IntersectionMember1FromRaw : IFromRawJson<UnionMember1IntersectionMember1>
{
    /// <inheritdoc/>
    public UnionMember1IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnionMember1IntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnionMember1IntersectionMember1TypeConverter))]
public enum UnionMember1IntersectionMember1Type
{
    Meta,
}

sealed class UnionMember1IntersectionMember1TypeConverter
    : JsonConverter<UnionMember1IntersectionMember1Type>
{
    public override UnionMember1IntersectionMember1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "meta" => UnionMember1IntersectionMember1Type.Meta,
            _ => (UnionMember1IntersectionMember1Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember1IntersectionMember1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionMember1IntersectionMember1Type.Meta => "meta",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Used to embed an image into the notification.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UnionMember2, UnionMember2FromRaw>))]
public sealed record class UnionMember2 : JsonModel
{
    public IReadOnlyList<string>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("channels");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "channels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? If
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("if");
        }
        init { this._rawData.Set("if", value); }
    }

    public string? Loop
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("loop");
        }
        init { this._rawData.Set("loop", value); }
    }

    public string? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ref");
        }
        init { this._rawData.Set("ref", value); }
    }

    /// <summary>
    /// The source of the image.
    /// </summary>
    public required string Src
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("src");
        }
        init { this._rawData.Set("src", value); }
    }

    public ApiEnum<string, Alignment>? Align
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Alignment>>("align");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("align", value);
        }
    }

    /// <summary>
    /// Alternate text for the image.
    /// </summary>
    public string? AltText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("alt_text");
        }
        init { this._rawData.Set("alt_text", value); }
    }

    /// <summary>
    /// CSS border color applied to the image. For example, `#ccc`
    /// </summary>
    public string? BorderColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border_color");
        }
        init { this._rawData.Set("border_color", value); }
    }

    /// <summary>
    /// CSS border width applied to the image. For example, `1px`
    /// </summary>
    public string? BorderSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border_size");
        }
        init { this._rawData.Set("border_size", value); }
    }

    /// <summary>
    /// A URL to link to when the image is clicked.
    /// </summary>
    public string? Href
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("href");
        }
        init { this._rawData.Set("href", value); }
    }

    /// <summary>
    /// CSS padding applied around the image. For example, `10px`
    /// </summary>
    public string? Padding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("padding");
        }
        init { this._rawData.Set("padding", value); }
    }

    /// <summary>
    /// CSS width properties to apply to the image. For example, 50px
    /// </summary>
    public string? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("width");
        }
        init { this._rawData.Set("width", value); }
    }

    public ApiEnum<string, UnionMember2IntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UnionMember2IntersectionMember1Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public static implicit operator ElementalImageNode(UnionMember2 unionMember2) =>
        new()
        {
            Channels = unionMember2.Channels,
            If = unionMember2.If,
            Loop = unionMember2.Loop,
            Ref = unionMember2.Ref,
            Src = unionMember2.Src,
            Align = unionMember2.Align,
            AltText = unionMember2.AltText,
            BorderColor = unionMember2.BorderColor,
            BorderSize = unionMember2.BorderSize,
            Href = unionMember2.Href,
            Padding = unionMember2.Padding,
            Width = unionMember2.Width,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channels;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        _ = this.Src;
        this.Align?.Validate();
        _ = this.AltText;
        _ = this.BorderColor;
        _ = this.BorderSize;
        _ = this.Href;
        _ = this.Padding;
        _ = this.Width;
        this.Type?.Validate();
    }

    public UnionMember2() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember2(UnionMember2 unionMember2)
        : base(unionMember2) { }
#pragma warning restore CS8618

    public UnionMember2(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember2(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember2FromRaw.FromRawUnchecked"/>
    public static UnionMember2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UnionMember2(string src)
        : this()
    {
        this.Src = src;
    }
}

class UnionMember2FromRaw : IFromRawJson<UnionMember2>
{
    /// <inheritdoc/>
    public UnionMember2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionMember2.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnionMember2IntersectionMember1,
        UnionMember2IntersectionMember1FromRaw
    >)
)]
public sealed record class UnionMember2IntersectionMember1 : JsonModel
{
    public ApiEnum<string, UnionMember2IntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UnionMember2IntersectionMember1Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type?.Validate();
    }

    public UnionMember2IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember2IntersectionMember1(
        UnionMember2IntersectionMember1 unionMember2IntersectionMember1
    )
        : base(unionMember2IntersectionMember1) { }
#pragma warning restore CS8618

    public UnionMember2IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember2IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember2IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static UnionMember2IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionMember2IntersectionMember1FromRaw : IFromRawJson<UnionMember2IntersectionMember1>
{
    /// <inheritdoc/>
    public UnionMember2IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnionMember2IntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnionMember2IntersectionMember1TypeConverter))]
public enum UnionMember2IntersectionMember1Type
{
    Image,
}

sealed class UnionMember2IntersectionMember1TypeConverter
    : JsonConverter<UnionMember2IntersectionMember1Type>
{
    public override UnionMember2IntersectionMember1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "image" => UnionMember2IntersectionMember1Type.Image,
            _ => (UnionMember2IntersectionMember1Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember2IntersectionMember1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionMember2IntersectionMember1Type.Image => "image",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Allows the user to execute an action. Can be a button or a link.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UnionMember3, UnionMember3FromRaw>))]
public sealed record class UnionMember3 : JsonModel
{
    public IReadOnlyList<string>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("channels");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "channels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? If
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("if");
        }
        init { this._rawData.Set("if", value); }
    }

    public string? Loop
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("loop");
        }
        init { this._rawData.Set("loop", value); }
    }

    public string? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ref");
        }
        init { this._rawData.Set("ref", value); }
    }

    /// <summary>
    /// The text content of the action shown to the user.
    /// </summary>
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// The target URL of the action.
    /// </summary>
    public required string Href
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("href");
        }
        init { this._rawData.Set("href", value); }
    }

    /// <summary>
    /// A unique id used to identify the action when it is executed.
    /// </summary>
    public string? ActionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("action_id");
        }
        init { this._rawData.Set("action_id", value); }
    }

    public ApiEnum<string, Alignment>? Align
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Alignment>>("align");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("align", value);
        }
    }

    /// <summary>
    /// The background color of the action button.
    /// </summary>
    public string? BackgroundColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("background_color");
        }
        init { this._rawData.Set("background_color", value); }
    }

    /// <summary>
    /// CSS border-radius applied to the action button. For example, `4px`
    /// </summary>
    public string? BorderRadius
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border_radius");
        }
        init { this._rawData.Set("border_radius", value); }
    }

    /// <summary>
    /// CSS border width applied to the action button. For example, `1px`
    /// </summary>
    public string? BorderSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border_size");
        }
        init { this._rawData.Set("border_size", value); }
    }

    /// <summary>
    /// When true, the action's href is not rewritten for click-through tracking,
    /// even when click-through tracking is enabled for the workspace.
    /// </summary>
    public bool? DisableTracking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("disable_tracking");
        }
        init { this._rawData.Set("disable_tracking", value); }
    }

    /// <summary>
    /// CSS font-size applied to the action button label. For example, `14px`
    /// </summary>
    public string? FontSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("font_size");
        }
        init { this._rawData.Set("font_size", value); }
    }

    /// <summary>
    /// Region specific content. See [locales docs](https://www.courier.com/docs/platform/content/elemental/locales/)
    /// for more details.
    /// </summary>
    public IReadOnlyDictionary<string, LocalesItem>? Locales
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, LocalesItem>>("locales");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, LocalesItem>?>(
                "locales",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// CSS padding applied to the action button. For example, `8px 16px`
    /// </summary>
    public string? Padding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("padding");
        }
        init { this._rawData.Set("padding", value); }
    }

    /// <summary>
    /// Defaults to `button`.
    /// </summary>
    public ApiEnum<string, Style>? Style
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Style>>("style");
        }
        init { this._rawData.Set("style", value); }
    }

    public ApiEnum<string, UnionMember3IntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UnionMember3IntersectionMember1Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public static implicit operator ElementalActionNode(UnionMember3 unionMember3) =>
        new()
        {
            Channels = unionMember3.Channels,
            If = unionMember3.If,
            Loop = unionMember3.Loop,
            Ref = unionMember3.Ref,
            Content = unionMember3.Content,
            Href = unionMember3.Href,
            ActionID = unionMember3.ActionID,
            Align = unionMember3.Align,
            BackgroundColor = unionMember3.BackgroundColor,
            BorderRadius = unionMember3.BorderRadius,
            BorderSize = unionMember3.BorderSize,
            DisableTracking = unionMember3.DisableTracking,
            FontSize = unionMember3.FontSize,
            Locales = unionMember3.Locales,
            Padding = unionMember3.Padding,
            Style = unionMember3.Style,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channels;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        _ = this.Content;
        _ = this.Href;
        _ = this.ActionID;
        this.Align?.Validate();
        _ = this.BackgroundColor;
        _ = this.BorderRadius;
        _ = this.BorderSize;
        _ = this.DisableTracking;
        _ = this.FontSize;
        if (this.Locales != null)
        {
            foreach (var item in this.Locales.Values)
            {
                item.Validate();
            }
        }
        _ = this.Padding;
        this.Style?.Validate();
        this.Type?.Validate();
    }

    public UnionMember3() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember3(UnionMember3 unionMember3)
        : base(unionMember3) { }
#pragma warning restore CS8618

    public UnionMember3(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember3(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember3FromRaw.FromRawUnchecked"/>
    public static UnionMember3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionMember3FromRaw : IFromRawJson<UnionMember3>
{
    /// <inheritdoc/>
    public UnionMember3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionMember3.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnionMember3IntersectionMember1,
        UnionMember3IntersectionMember1FromRaw
    >)
)]
public sealed record class UnionMember3IntersectionMember1 : JsonModel
{
    public ApiEnum<string, UnionMember3IntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UnionMember3IntersectionMember1Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type?.Validate();
    }

    public UnionMember3IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember3IntersectionMember1(
        UnionMember3IntersectionMember1 unionMember3IntersectionMember1
    )
        : base(unionMember3IntersectionMember1) { }
#pragma warning restore CS8618

    public UnionMember3IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember3IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember3IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static UnionMember3IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionMember3IntersectionMember1FromRaw : IFromRawJson<UnionMember3IntersectionMember1>
{
    /// <inheritdoc/>
    public UnionMember3IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnionMember3IntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnionMember3IntersectionMember1TypeConverter))]
public enum UnionMember3IntersectionMember1Type
{
    Action,
}

sealed class UnionMember3IntersectionMember1TypeConverter
    : JsonConverter<UnionMember3IntersectionMember1Type>
{
    public override UnionMember3IntersectionMember1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "action" => UnionMember3IntersectionMember1Type.Action,
            _ => (UnionMember3IntersectionMember1Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember3IntersectionMember1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionMember3IntersectionMember1Type.Action => "action",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Renders a dividing line between elements.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UnionMember4, UnionMember4FromRaw>))]
public sealed record class UnionMember4 : JsonModel
{
    public IReadOnlyList<string>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("channels");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "channels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? If
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("if");
        }
        init { this._rawData.Set("if", value); }
    }

    public string? Loop
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("loop");
        }
        init { this._rawData.Set("loop", value); }
    }

    public string? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ref");
        }
        init { this._rawData.Set("ref", value); }
    }

    /// <summary>
    /// The CSS color to render the line with. For example, `#fff`
    /// </summary>
    public string? Color
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("color");
        }
        init { this._rawData.Set("color", value); }
    }

    public ApiEnum<string, UnionMember4IntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UnionMember4IntersectionMember1Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public static implicit operator ElementalDividerNode(UnionMember4 unionMember4) =>
        new()
        {
            Channels = unionMember4.Channels,
            If = unionMember4.If,
            Loop = unionMember4.Loop,
            Ref = unionMember4.Ref,
            Color = unionMember4.Color,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channels;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        _ = this.Color;
        this.Type?.Validate();
    }

    public UnionMember4() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember4(UnionMember4 unionMember4)
        : base(unionMember4) { }
#pragma warning restore CS8618

    public UnionMember4(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember4(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember4FromRaw.FromRawUnchecked"/>
    public static UnionMember4 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionMember4FromRaw : IFromRawJson<UnionMember4>
{
    /// <inheritdoc/>
    public UnionMember4 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionMember4.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnionMember4IntersectionMember1,
        UnionMember4IntersectionMember1FromRaw
    >)
)]
public sealed record class UnionMember4IntersectionMember1 : JsonModel
{
    public ApiEnum<string, UnionMember4IntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UnionMember4IntersectionMember1Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type?.Validate();
    }

    public UnionMember4IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember4IntersectionMember1(
        UnionMember4IntersectionMember1 unionMember4IntersectionMember1
    )
        : base(unionMember4IntersectionMember1) { }
#pragma warning restore CS8618

    public UnionMember4IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember4IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember4IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static UnionMember4IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionMember4IntersectionMember1FromRaw : IFromRawJson<UnionMember4IntersectionMember1>
{
    /// <inheritdoc/>
    public UnionMember4IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnionMember4IntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnionMember4IntersectionMember1TypeConverter))]
public enum UnionMember4IntersectionMember1Type
{
    Divider,
}

sealed class UnionMember4IntersectionMember1TypeConverter
    : JsonConverter<UnionMember4IntersectionMember1Type>
{
    public override UnionMember4IntersectionMember1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "divider" => UnionMember4IntersectionMember1Type.Divider,
            _ => (UnionMember4IntersectionMember1Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember4IntersectionMember1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionMember4IntersectionMember1Type.Divider => "divider",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Renders a quote block.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UnionMember5, UnionMember5FromRaw>))]
public sealed record class UnionMember5 : JsonModel
{
    public IReadOnlyList<string>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("channels");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "channels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? If
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("if");
        }
        init { this._rawData.Set("if", value); }
    }

    public string? Loop
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("loop");
        }
        init { this._rawData.Set("loop", value); }
    }

    public string? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ref");
        }
        init { this._rawData.Set("ref", value); }
    }

    /// <summary>
    /// The text value of the quote.
    /// </summary>
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public ApiEnum<string, Alignment>? Align
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Alignment>>("align");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("align", value);
        }
    }

    /// <summary>
    /// CSS border color property. For example, `#fff`
    /// </summary>
    public string? BorderColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border_color");
        }
        init { this._rawData.Set("border_color", value); }
    }

    /// <summary>
    /// CSS px font size for this quote block, e.g. `16px`. Overrides the size of
    /// the `text_style` preset. Email only.
    /// </summary>
    public string? FontSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("font_size");
        }
        init { this._rawData.Set("font_size", value); }
    }

    /// <summary>
    /// CSS line height for this quote block, as a px value or a unitless multiplier,
    /// e.g. `24px` or `1.5`. Email only.
    /// </summary>
    public string? LineHeight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line_height");
        }
        init { this._rawData.Set("line_height", value); }
    }

    /// <summary>
    /// Region specific content. See [locales docs](https://www.courier.com/docs/platform/content/elemental/locales/)
    /// for more details.
    /// </summary>
    public IReadOnlyDictionary<string, LocalesItem>? Locales
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, LocalesItem>>("locales");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, LocalesItem>?>(
                "locales",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public ApiEnum<string, TextStyle>? TextStyle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TextStyle>>("text_style");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text_style", value);
        }
    }

    public ApiEnum<string, UnionMember5IntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UnionMember5IntersectionMember1Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public static implicit operator ElementalQuoteNode(UnionMember5 unionMember5) =>
        new()
        {
            Channels = unionMember5.Channels,
            If = unionMember5.If,
            Loop = unionMember5.Loop,
            Ref = unionMember5.Ref,
            Content = unionMember5.Content,
            Align = unionMember5.Align,
            BorderColor = unionMember5.BorderColor,
            FontSize = unionMember5.FontSize,
            LineHeight = unionMember5.LineHeight,
            Locales = unionMember5.Locales,
            TextStyle = unionMember5.TextStyle,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channels;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        _ = this.Content;
        this.Align?.Validate();
        _ = this.BorderColor;
        _ = this.FontSize;
        _ = this.LineHeight;
        if (this.Locales != null)
        {
            foreach (var item in this.Locales.Values)
            {
                item.Validate();
            }
        }
        this.TextStyle?.Validate();
        this.Type?.Validate();
    }

    public UnionMember5() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember5(UnionMember5 unionMember5)
        : base(unionMember5) { }
#pragma warning restore CS8618

    public UnionMember5(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember5(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember5FromRaw.FromRawUnchecked"/>
    public static UnionMember5 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UnionMember5(string content)
        : this()
    {
        this.Content = content;
    }
}

class UnionMember5FromRaw : IFromRawJson<UnionMember5>
{
    /// <inheritdoc/>
    public UnionMember5 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionMember5.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnionMember5IntersectionMember1,
        UnionMember5IntersectionMember1FromRaw
    >)
)]
public sealed record class UnionMember5IntersectionMember1 : JsonModel
{
    public ApiEnum<string, UnionMember5IntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UnionMember5IntersectionMember1Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type?.Validate();
    }

    public UnionMember5IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember5IntersectionMember1(
        UnionMember5IntersectionMember1 unionMember5IntersectionMember1
    )
        : base(unionMember5IntersectionMember1) { }
#pragma warning restore CS8618

    public UnionMember5IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember5IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember5IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static UnionMember5IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionMember5IntersectionMember1FromRaw : IFromRawJson<UnionMember5IntersectionMember1>
{
    /// <inheritdoc/>
    public UnionMember5IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnionMember5IntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnionMember5IntersectionMember1TypeConverter))]
public enum UnionMember5IntersectionMember1Type
{
    Quote,
}

sealed class UnionMember5IntersectionMember1TypeConverter
    : JsonConverter<UnionMember5IntersectionMember1Type>
{
    public override UnionMember5IntersectionMember1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "quote" => UnionMember5IntersectionMember1Type.Quote,
            _ => (UnionMember5IntersectionMember1Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember5IntersectionMember1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionMember5IntersectionMember1Type.Quote => "quote",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Raw HTML string inside an Elemental document. When rendering a message, this
/// node is turned into output only for the email channel; for other channels it
/// produces no blocks.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UnionMember6, UnionMember6FromRaw>))]
public sealed record class UnionMember6 : JsonModel
{
    public IReadOnlyList<string>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("channels");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "channels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? If
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("if");
        }
        init { this._rawData.Set("if", value); }
    }

    public string? Loop
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("loop");
        }
        init { this._rawData.Set("loop", value); }
    }

    public string? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ref");
        }
        init { this._rawData.Set("ref", value); }
    }

    /// <summary>
    /// Raw HTML string to render inside the notification.
    /// </summary>
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// Region specific content. See [locales docs](https://www.courier.com/docs/platform/content/elemental/locales/)
    /// for more details.
    /// </summary>
    public IReadOnlyDictionary<string, LocalesItem>? Locales
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, LocalesItem>>("locales");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, LocalesItem>?>(
                "locales",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public ApiEnum<string, UnionMember6IntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UnionMember6IntersectionMember1Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public static implicit operator ElementalHtmlNode(UnionMember6 unionMember6) =>
        new()
        {
            Channels = unionMember6.Channels,
            If = unionMember6.If,
            Loop = unionMember6.Loop,
            Ref = unionMember6.Ref,
            Content = unionMember6.Content,
            Locales = unionMember6.Locales,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channels;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        _ = this.Content;
        if (this.Locales != null)
        {
            foreach (var item in this.Locales.Values)
            {
                item.Validate();
            }
        }
        this.Type?.Validate();
    }

    public UnionMember6() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember6(UnionMember6 unionMember6)
        : base(unionMember6) { }
#pragma warning restore CS8618

    public UnionMember6(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember6(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember6FromRaw.FromRawUnchecked"/>
    public static UnionMember6 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UnionMember6(string content)
        : this()
    {
        this.Content = content;
    }
}

class UnionMember6FromRaw : IFromRawJson<UnionMember6>
{
    /// <inheritdoc/>
    public UnionMember6 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionMember6.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnionMember6IntersectionMember1,
        UnionMember6IntersectionMember1FromRaw
    >)
)]
public sealed record class UnionMember6IntersectionMember1 : JsonModel
{
    public ApiEnum<string, UnionMember6IntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UnionMember6IntersectionMember1Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type?.Validate();
    }

    public UnionMember6IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember6IntersectionMember1(
        UnionMember6IntersectionMember1 unionMember6IntersectionMember1
    )
        : base(unionMember6IntersectionMember1) { }
#pragma warning restore CS8618

    public UnionMember6IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember6IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember6IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static UnionMember6IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionMember6IntersectionMember1FromRaw : IFromRawJson<UnionMember6IntersectionMember1>
{
    /// <inheritdoc/>
    public UnionMember6IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnionMember6IntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnionMember6IntersectionMember1TypeConverter))]
public enum UnionMember6IntersectionMember1Type
{
    Html,
}

sealed class UnionMember6IntersectionMember1TypeConverter
    : JsonConverter<UnionMember6IntersectionMember1Type>
{
    public override UnionMember6IntersectionMember1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "html" => UnionMember6IntersectionMember1Type.Html,
            _ => (UnionMember6IntersectionMember1Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember6IntersectionMember1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionMember6IntersectionMember1Type.Html => "html",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
