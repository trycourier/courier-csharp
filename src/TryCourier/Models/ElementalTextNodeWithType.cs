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
/// Represents a body of text to be rendered inside of the notification.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ElementalTextNodeWithType, ElementalTextNodeWithTypeFromRaw>)
)]
public sealed record class ElementalTextNodeWithType : JsonModel
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

    public ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type>
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

    public static implicit operator ElementalTextNode(
        ElementalTextNodeWithType elementalTextNodeWithType
    ) =>
        new()
        {
            Channels = elementalTextNodeWithType.Channels,
            If = elementalTextNodeWithType.If,
            Loop = elementalTextNodeWithType.Loop,
            Ref = elementalTextNodeWithType.Ref,
            Align = elementalTextNodeWithType.Align,
            Bold = elementalTextNodeWithType.Bold,
            Color = elementalTextNodeWithType.Color,
            Content = elementalTextNodeWithType.Content,
            FontSize = elementalTextNodeWithType.FontSize,
            Format = elementalTextNodeWithType.Format,
            Italic = elementalTextNodeWithType.Italic,
            LineHeight = elementalTextNodeWithType.LineHeight,
            Locales = elementalTextNodeWithType.Locales,
            Strikethrough = elementalTextNodeWithType.Strikethrough,
            TextStyle = elementalTextNodeWithType.TextStyle,
            Underline = elementalTextNodeWithType.Underline,
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

    public ElementalTextNodeWithType() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalTextNodeWithType(ElementalTextNodeWithType elementalTextNodeWithType)
        : base(elementalTextNodeWithType) { }
#pragma warning restore CS8618

    public ElementalTextNodeWithType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalTextNodeWithType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalTextNodeWithTypeFromRaw.FromRawUnchecked"/>
    public static ElementalTextNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalTextNodeWithTypeFromRaw : IFromRawJson<ElementalTextNodeWithType>
{
    /// <inheritdoc/>
    public ElementalTextNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalTextNodeWithType.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ElementalTextNodeWithTypeIntersectionMember1,
        ElementalTextNodeWithTypeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalTextNodeWithTypeIntersectionMember1 : JsonModel
{
    public ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type>
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

    public ElementalTextNodeWithTypeIntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalTextNodeWithTypeIntersectionMember1(
        ElementalTextNodeWithTypeIntersectionMember1 elementalTextNodeWithTypeIntersectionMember1
    )
        : base(elementalTextNodeWithTypeIntersectionMember1) { }
#pragma warning restore CS8618

    public ElementalTextNodeWithTypeIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalTextNodeWithTypeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalTextNodeWithTypeIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static ElementalTextNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalTextNodeWithTypeIntersectionMember1FromRaw
    : IFromRawJson<ElementalTextNodeWithTypeIntersectionMember1>
{
    /// <inheritdoc/>
    public ElementalTextNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalTextNodeWithTypeIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ElementalTextNodeWithTypeIntersectionMember1TypeConverter))]
public enum ElementalTextNodeWithTypeIntersectionMember1Type
{
    Text,
}

sealed class ElementalTextNodeWithTypeIntersectionMember1TypeConverter
    : JsonConverter<ElementalTextNodeWithTypeIntersectionMember1Type>
{
    public override ElementalTextNodeWithTypeIntersectionMember1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => ElementalTextNodeWithTypeIntersectionMember1Type.Text,
            _ => (ElementalTextNodeWithTypeIntersectionMember1Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ElementalTextNodeWithTypeIntersectionMember1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ElementalTextNodeWithTypeIntersectionMember1Type.Text => "text",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
