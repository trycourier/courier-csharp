using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<BrandSnippets, BrandSnippetsFromRaw>))]
public sealed record class BrandSnippets : ModelBase
{
    public IReadOnlyList<BrandSnippet>? Items
    {
        get { return ModelBase.GetNullableClass<List<BrandSnippet>>(this.RawData, "items"); }
        init { ModelBase.Set(this._rawData, "items", value); }
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

    public BrandSnippets(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSnippets(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandSnippetsFromRaw.FromRawUnchecked"/>
    public static BrandSnippets FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandSnippetsFromRaw : IFromRaw<BrandSnippets>
{
    /// <inheritdoc/>
    public BrandSnippets FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandSnippets.FromRawUnchecked(rawData);
}
