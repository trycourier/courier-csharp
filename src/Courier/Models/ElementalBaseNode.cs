using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<ElementalBaseNode, ElementalBaseNodeFromRaw>))]
public sealed record class ElementalBaseNode : ModelBase
{
    public IReadOnlyList<string>? Channels
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "channels"); }
        init { ModelBase.Set(this._rawData, "channels", value); }
    }

    public string? If
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "if"); }
        init { ModelBase.Set(this._rawData, "if", value); }
    }

    public string? Loop
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "loop"); }
        init { ModelBase.Set(this._rawData, "loop", value); }
    }

    public string? Ref
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "ref"); }
        init { ModelBase.Set(this._rawData, "ref", value); }
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

    public ElementalBaseNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalBaseNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class ElementalBaseNodeFromRaw : IFromRaw<ElementalBaseNode>
{
    /// <inheritdoc/>
    public ElementalBaseNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ElementalBaseNode.FromRawUnchecked(rawData);
}
