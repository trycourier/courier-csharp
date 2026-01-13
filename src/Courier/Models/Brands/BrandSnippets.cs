using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandSnippets, BrandSnippetsFromRaw>))]
public sealed record class BrandSnippets : JsonModel
{
    public IReadOnlyList<BrandSnippet>? Items
    {
        get { return this._rawData.GetNullableStruct<ImmutableArray<BrandSnippet>>("items"); }
        init
        {
            this._rawData.Set<ImmutableArray<BrandSnippet>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
    }

    public BrandSnippets() { }

    public BrandSnippets(BrandSnippets brandSnippets)
        : base(brandSnippets) { }

    public BrandSnippets(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSnippets(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandSnippetsFromRaw.FromRawUnchecked"/>
    public static BrandSnippets FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandSnippetsFromRaw : IFromRawJson<BrandSnippets>
{
    /// <inheritdoc/>
    public BrandSnippets FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandSnippets.FromRawUnchecked(rawData);
}
