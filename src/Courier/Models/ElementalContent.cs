using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ElementalNode>>("elements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ElementalNode>>(
                "elements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// For example, "2022-01-01"
    /// </summary>
    public required string Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Elements)
        {
            item.Validate();
        }
        _ = this.Version;
    }

    public ElementalContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalContent(ElementalContent elementalContent)
        : base(elementalContent) { }
#pragma warning restore CS8618

    public ElementalContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
