using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models;

/// <summary>
/// Renders a dividing line between elements.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ElementalDividerNode, ElementalDividerNodeFromRaw>))]
public sealed record class ElementalDividerNode : JsonModel
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

    public static implicit operator ElementalBaseNode(ElementalDividerNode elementalDividerNode) =>
        new()
        {
            Channels = elementalDividerNode.Channels,
            If = elementalDividerNode.If,
            Loop = elementalDividerNode.Loop,
            Ref = elementalDividerNode.Ref,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channels;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        _ = this.Color;
    }

    public ElementalDividerNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalDividerNode(ElementalDividerNode elementalDividerNode)
        : base(elementalDividerNode) { }
#pragma warning restore CS8618

    public ElementalDividerNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalDividerNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalDividerNodeFromRaw.FromRawUnchecked"/>
    public static ElementalDividerNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalDividerNodeFromRaw : IFromRawJson<ElementalDividerNode>
{
    /// <inheritdoc/>
    public ElementalDividerNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalDividerNode.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ElementalDividerNodeIntersectionMember1,
        ElementalDividerNodeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalDividerNodeIntersectionMember1 : JsonModel
{
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Color;
    }

    public ElementalDividerNodeIntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalDividerNodeIntersectionMember1(
        ElementalDividerNodeIntersectionMember1 elementalDividerNodeIntersectionMember1
    )
        : base(elementalDividerNodeIntersectionMember1) { }
#pragma warning restore CS8618

    public ElementalDividerNodeIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalDividerNodeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalDividerNodeIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static ElementalDividerNodeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalDividerNodeIntersectionMember1FromRaw
    : IFromRawJson<ElementalDividerNodeIntersectionMember1>
{
    /// <inheritdoc/>
    public ElementalDividerNodeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalDividerNodeIntersectionMember1.FromRawUnchecked(rawData);
}
