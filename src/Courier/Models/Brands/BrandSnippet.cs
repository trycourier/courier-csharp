using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandSnippet, BrandSnippetFromRaw>))]
public sealed record class BrandSnippet : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Value;
    }

    public BrandSnippet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandSnippet(BrandSnippet brandSnippet)
        : base(brandSnippet) { }
#pragma warning restore CS8618

    public BrandSnippet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSnippet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandSnippetFromRaw.FromRawUnchecked"/>
    public static BrandSnippet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandSnippetFromRaw : IFromRawJson<BrandSnippet>
{
    /// <inheritdoc/>
    public BrandSnippet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandSnippet.FromRawUnchecked(rawData);
}
