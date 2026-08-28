using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models;

/// <summary>
/// The meta element contains information describing the notification that may  be
/// used by a particular channel or provider. One important field is the title  field
/// which will be used as the title for channels that support it.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ElementalMetaNode, ElementalMetaNodeFromRaw>))]
public sealed record class ElementalMetaNode : JsonModel
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

    public static implicit operator ElementalBaseNode(ElementalMetaNode elementalMetaNode) =>
        new()
        {
            Channels = elementalMetaNode.Channels,
            If = elementalMetaNode.If,
            Loop = elementalMetaNode.Loop,
            Ref = elementalMetaNode.Ref,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channels;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        _ = this.Title;
    }

    public ElementalMetaNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalMetaNode(ElementalMetaNode elementalMetaNode)
        : base(elementalMetaNode) { }
#pragma warning restore CS8618

    public ElementalMetaNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalMetaNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalMetaNodeFromRaw.FromRawUnchecked"/>
    public static ElementalMetaNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalMetaNodeFromRaw : IFromRawJson<ElementalMetaNode>
{
    /// <inheritdoc/>
    public ElementalMetaNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ElementalMetaNode.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ElementalMetaNodeIntersectionMember1,
        ElementalMetaNodeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalMetaNodeIntersectionMember1 : JsonModel
{
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Title;
    }

    public ElementalMetaNodeIntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalMetaNodeIntersectionMember1(
        ElementalMetaNodeIntersectionMember1 elementalMetaNodeIntersectionMember1
    )
        : base(elementalMetaNodeIntersectionMember1) { }
#pragma warning restore CS8618

    public ElementalMetaNodeIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalMetaNodeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalMetaNodeIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static ElementalMetaNodeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalMetaNodeIntersectionMember1FromRaw
    : IFromRawJson<ElementalMetaNodeIntersectionMember1>
{
    /// <inheritdoc/>
    public ElementalMetaNodeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalMetaNodeIntersectionMember1.FromRawUnchecked(rawData);
}
