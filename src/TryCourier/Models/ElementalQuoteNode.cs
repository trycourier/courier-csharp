using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models;

/// <summary>
/// Renders a quote block.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ElementalQuoteNode, ElementalQuoteNodeFromRaw>))]
public sealed record class ElementalQuoteNode : JsonModel
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

    public static implicit operator ElementalBaseNode(ElementalQuoteNode elementalQuoteNode) =>
        new()
        {
            Channels = elementalQuoteNode.Channels,
            If = elementalQuoteNode.If,
            Loop = elementalQuoteNode.Loop,
            Ref = elementalQuoteNode.Ref,
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
    }

    public ElementalQuoteNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalQuoteNode(ElementalQuoteNode elementalQuoteNode)
        : base(elementalQuoteNode) { }
#pragma warning restore CS8618

    public ElementalQuoteNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalQuoteNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalQuoteNodeFromRaw.FromRawUnchecked"/>
    public static ElementalQuoteNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ElementalQuoteNode(string content)
        : this()
    {
        this.Content = content;
    }
}

class ElementalQuoteNodeFromRaw : IFromRawJson<ElementalQuoteNode>
{
    /// <inheritdoc/>
    public ElementalQuoteNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ElementalQuoteNode.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ElementalQuoteNodeIntersectionMember1,
        ElementalQuoteNodeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalQuoteNodeIntersectionMember1 : JsonModel
{
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

    /// <summary>
    /// Alignment of the quote.
    /// </summary>
    public ApiEnum<string, Alignment>? Align
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Alignment>>("align");
        }
        init { this._rawData.Set("align", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
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
    }

    public ElementalQuoteNodeIntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalQuoteNodeIntersectionMember1(
        ElementalQuoteNodeIntersectionMember1 elementalQuoteNodeIntersectionMember1
    )
        : base(elementalQuoteNodeIntersectionMember1) { }
#pragma warning restore CS8618

    public ElementalQuoteNodeIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalQuoteNodeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalQuoteNodeIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static ElementalQuoteNodeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ElementalQuoteNodeIntersectionMember1(string content)
        : this()
    {
        this.Content = content;
    }
}

class ElementalQuoteNodeIntersectionMember1FromRaw
    : IFromRawJson<ElementalQuoteNodeIntersectionMember1>
{
    /// <inheritdoc/>
    public ElementalQuoteNodeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalQuoteNodeIntersectionMember1.FromRawUnchecked(rawData);
}
