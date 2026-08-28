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
[JsonConverter(typeof(JsonModelConverter<ElementalTextNode, ElementalTextNodeFromRaw>))]
public sealed record class ElementalTextNode : JsonModel
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
    /// The text content displayed in the notification. Either this field must be
    /// specified, or the elements field
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

    public static implicit operator ElementalBaseNode(ElementalTextNode elementalTextNode) =>
        new()
        {
            Channels = elementalTextNode.Channels,
            If = elementalTextNode.If,
            Loop = elementalTextNode.Loop,
            Ref = elementalTextNode.Ref,
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
        _ = this.Bold;
        _ = this.Color;
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
    }

    public ElementalTextNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalTextNode(ElementalTextNode elementalTextNode)
        : base(elementalTextNode) { }
#pragma warning restore CS8618

    public ElementalTextNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalTextNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalTextNodeFromRaw.FromRawUnchecked"/>
    public static ElementalTextNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ElementalTextNode(string content)
        : this()
    {
        this.Content = content;
    }
}

class ElementalTextNodeFromRaw : IFromRawJson<ElementalTextNode>
{
    /// <inheritdoc/>
    public ElementalTextNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ElementalTextNode.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ElementalTextNodeIntersectionMember1,
        ElementalTextNodeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalTextNodeIntersectionMember1 : JsonModel
{
    /// <summary>
    /// The text content displayed in the notification. Either this field must be
    /// specified, or the elements field
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

    /// <summary>
    /// Allows the text to be rendered as a heading level.
    /// </summary>
    public ApiEnum<string, TextStyle>? TextStyle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TextStyle>>("text_style");
        }
        init { this._rawData.Set("text_style", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.Align?.Validate();
        _ = this.Bold;
        _ = this.Color;
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
    }

    public ElementalTextNodeIntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalTextNodeIntersectionMember1(
        ElementalTextNodeIntersectionMember1 elementalTextNodeIntersectionMember1
    )
        : base(elementalTextNodeIntersectionMember1) { }
#pragma warning restore CS8618

    public ElementalTextNodeIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalTextNodeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalTextNodeIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static ElementalTextNodeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ElementalTextNodeIntersectionMember1(string content)
        : this()
    {
        this.Content = content;
    }
}

class ElementalTextNodeIntersectionMember1FromRaw
    : IFromRawJson<ElementalTextNodeIntersectionMember1>
{
    /// <inheritdoc/>
    public ElementalTextNodeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalTextNodeIntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// Text alignment.
/// </summary>
[JsonConverter(typeof(AlignConverter))]
public enum Align
{
    Left,
    Center,
    Right,
}

sealed class AlignConverter : JsonConverter<Align>
{
    public override Align Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "left" => Align.Left,
            "center" => Align.Center,
            "right" => Align.Right,
            _ => (Align)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Align value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Align.Left => "left",
                Align.Center => "center",
                Align.Right => "right",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(FormatConverter))]
public enum Format
{
    Markdown,
}

sealed class FormatConverter : JsonConverter<Format>
{
    public override Format Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "markdown" => Format.Markdown,
            _ => (Format)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Format value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Format.Markdown => "markdown",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
