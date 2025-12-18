using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<ElementalContent, ElementalContentFromRaw>))]
public sealed record class ElementalContent : JsonModel
{
    public required IReadOnlyList<ElementalNode> Elements
    {
        get { return JsonModel.GetNotNullClass<List<ElementalNode>>(this.RawData, "elements"); }
        init { JsonModel.Set(this._rawData, "elements", value); }
    }

    /// <summary>
    /// For example, "2022-01-01"
    /// </summary>
    public required string Version
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "version"); }
        init { JsonModel.Set(this._rawData, "version", value); }
    }

    public string? Brand
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "brand"); }
        init { JsonModel.Set(this._rawData, "brand", value); }
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

class ElementalContentFromRaw : IFromRawJson<ElementalContent>
{
    /// <inheritdoc/>
    public ElementalContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ElementalContent.FromRawUnchecked(rawData);
}
