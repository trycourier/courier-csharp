using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<ElementalBaseNode, ElementalBaseNodeFromRaw>))]
public sealed record class ElementalBaseNode : JsonModel
{
    public IReadOnlyList<string>? Channels
    {
        get { return this._rawData.GetNullableStruct<ImmutableArray<string>>("channels"); }
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
        get { return this._rawData.GetNullableClass<string>("if"); }
        init { this._rawData.Set("if", value); }
    }

    public string? Loop
    {
        get { return this._rawData.GetNullableClass<string>("loop"); }
        init { this._rawData.Set("loop", value); }
    }

    public string? Ref
    {
        get { return this._rawData.GetNullableClass<string>("ref"); }
        init { this._rawData.Set("ref", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channels;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
    }

    public ElementalBaseNode() { }

    public ElementalBaseNode(ElementalBaseNode elementalBaseNode)
        : base(elementalBaseNode) { }

    public ElementalBaseNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalBaseNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalBaseNodeFromRaw.FromRawUnchecked"/>
    public static ElementalBaseNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalBaseNodeFromRaw : IFromRawJson<ElementalBaseNode>
{
    /// <inheritdoc/>
    public ElementalBaseNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ElementalBaseNode.FromRawUnchecked(rawData);
}
