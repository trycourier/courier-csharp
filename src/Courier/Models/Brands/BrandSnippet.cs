using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<BrandSnippet, BrandSnippetFromRaw>))]
public sealed record class BrandSnippet : ModelBase
{
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public required string Value
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "value"); }
        init { ModelBase.Set(this._rawData, "value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Value;
    }

    public BrandSnippet() { }

    public BrandSnippet(BrandSnippet brandSnippet)
        : base(brandSnippet) { }

    public BrandSnippet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSnippet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandSnippetFromRaw.FromRawUnchecked"/>
    public static BrandSnippet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandSnippetFromRaw : IFromRaw<BrandSnippet>
{
    /// <inheritdoc/>
    public BrandSnippet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandSnippet.FromRawUnchecked(rawData);
}
