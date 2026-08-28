using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models;

/// <summary>
/// Used to embed an image into the notification.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ElementalImageNode, ElementalImageNodeFromRaw>))]
public sealed record class ElementalImageNode : JsonModel
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
            return this._rawData.GetNullableClass<string>("altText");
        }
        init { this._rawData.Set("altText", value); }
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

    public static implicit operator ElementalBaseNode(ElementalImageNode elementalImageNode) =>
        new()
        {
            Channels = elementalImageNode.Channels,
            If = elementalImageNode.If,
            Loop = elementalImageNode.Loop,
            Ref = elementalImageNode.Ref,
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
    }

    public ElementalImageNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalImageNode(ElementalImageNode elementalImageNode)
        : base(elementalImageNode) { }
#pragma warning restore CS8618

    public ElementalImageNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalImageNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalImageNodeFromRaw.FromRawUnchecked"/>
    public static ElementalImageNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ElementalImageNode(string src)
        : this()
    {
        this.Src = src;
    }
}

class ElementalImageNodeFromRaw : IFromRawJson<ElementalImageNode>
{
    /// <inheritdoc/>
    public ElementalImageNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ElementalImageNode.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ElementalImageNodeIntersectionMember1,
        ElementalImageNodeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalImageNodeIntersectionMember1 : JsonModel
{
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

    /// <summary>
    /// The alignment of the image.
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
    /// Alternate text for the image.
    /// </summary>
    public string? AltText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("altText");
        }
        init { this._rawData.Set("altText", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Src;
        this.Align?.Validate();
        _ = this.AltText;
        _ = this.BorderColor;
        _ = this.BorderSize;
        _ = this.Href;
        _ = this.Padding;
        _ = this.Width;
    }

    public ElementalImageNodeIntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalImageNodeIntersectionMember1(
        ElementalImageNodeIntersectionMember1 elementalImageNodeIntersectionMember1
    )
        : base(elementalImageNodeIntersectionMember1) { }
#pragma warning restore CS8618

    public ElementalImageNodeIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalImageNodeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalImageNodeIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static ElementalImageNodeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ElementalImageNodeIntersectionMember1(string src)
        : this()
    {
        this.Src = src;
    }
}

class ElementalImageNodeIntersectionMember1FromRaw
    : IFromRawJson<ElementalImageNodeIntersectionMember1>
{
    /// <inheritdoc/>
    public ElementalImageNodeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalImageNodeIntersectionMember1.FromRawUnchecked(rawData);
}
