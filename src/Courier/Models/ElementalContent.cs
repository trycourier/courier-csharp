using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<ElementalContent, ElementalContentFromRaw>))]
public sealed record class ElementalContent : ModelBase
{
    public required IReadOnlyList<ElementalNode> Elements
    {
        get { return ModelBase.GetNotNullClass<List<ElementalNode>>(this.RawData, "elements"); }
        init { ModelBase.Set(this._rawData, "elements", value); }
    }

    /// <summary>
    /// For example, "2022-01-01"
    /// </summary>
    public required string Version
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "version"); }
        init { ModelBase.Set(this._rawData, "version", value); }
    }

    public string? Brand
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "brand"); }
        init { ModelBase.Set(this._rawData, "brand", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Elements)
        {
            item.Validate();
        }
        _ = this.Version;
        _ = this.Brand;
    }

    public ElementalContent() { }

    public ElementalContent(ElementalContent elementalContent)
        : base(elementalContent) { }

    public ElementalContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalContentFromRaw.FromRawUnchecked"/>
    public static ElementalContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalContentFromRaw : IFromRaw<ElementalContent>
{
    /// <inheritdoc/>
    public ElementalContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ElementalContent.FromRawUnchecked(rawData);
}
