using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models;

/// <summary>
/// Raw HTML string inside an Elemental document. When rendering a message, this
/// node is turned into output only for the email channel; for other channels it
/// produces no blocks.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ElementalHtmlNode, ElementalHtmlNodeFromRaw>))]
public sealed record class ElementalHtmlNode : JsonModel
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

    public static implicit operator ElementalBaseNode(ElementalHtmlNode elementalHtmlNode) =>
        new()
        {
            Channels = elementalHtmlNode.Channels,
            If = elementalHtmlNode.If,
            Loop = elementalHtmlNode.Loop,
            Ref = elementalHtmlNode.Ref,
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
    }

    public ElementalHtmlNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalHtmlNode(ElementalHtmlNode elementalHtmlNode)
        : base(elementalHtmlNode) { }
#pragma warning restore CS8618

    public ElementalHtmlNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalHtmlNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalHtmlNodeFromRaw.FromRawUnchecked"/>
    public static ElementalHtmlNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ElementalHtmlNode(string content)
        : this()
    {
        this.Content = content;
    }
}

class ElementalHtmlNodeFromRaw : IFromRawJson<ElementalHtmlNode>
{
    /// <inheritdoc/>
    public ElementalHtmlNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ElementalHtmlNode.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ElementalHtmlNodeIntersectionMember1,
        ElementalHtmlNodeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalHtmlNodeIntersectionMember1 : JsonModel
{
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        if (this.Locales != null)
        {
            foreach (var item in this.Locales.Values)
            {
                item.Validate();
            }
        }
    }

    public ElementalHtmlNodeIntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalHtmlNodeIntersectionMember1(
        ElementalHtmlNodeIntersectionMember1 elementalHtmlNodeIntersectionMember1
    )
        : base(elementalHtmlNodeIntersectionMember1) { }
#pragma warning restore CS8618

    public ElementalHtmlNodeIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalHtmlNodeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalHtmlNodeIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static ElementalHtmlNodeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ElementalHtmlNodeIntersectionMember1(string content)
        : this()
    {
        this.Content = content;
    }
}

class ElementalHtmlNodeIntersectionMember1FromRaw
    : IFromRawJson<ElementalHtmlNodeIntersectionMember1>
{
    /// <inheritdoc/>
    public ElementalHtmlNodeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalHtmlNodeIntersectionMember1.FromRawUnchecked(rawData);
}
