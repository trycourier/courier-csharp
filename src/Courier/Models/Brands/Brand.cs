using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<Brand, BrandFromRaw>))]
public sealed record class Brand : JsonModel
{
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    public required long Created
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "created"); }
        init { JsonModel.Set(this._rawData, "created", value); }
    }

    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    public required long Updated
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "updated"); }
        init { JsonModel.Set(this._rawData, "updated", value); }
    }

    public long? Published
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "published"); }
        init { JsonModel.Set(this._rawData, "published", value); }
    }

    public BrandSettings? Settings
    {
        get { return JsonModel.GetNullableClass<BrandSettings>(this.RawData, "settings"); }
        init { JsonModel.Set(this._rawData, "settings", value); }
    }

    public BrandSnippets? Snippets
    {
        get { return JsonModel.GetNullableClass<BrandSnippets>(this.RawData, "snippets"); }
        init { JsonModel.Set(this._rawData, "snippets", value); }
    }

    public string? Version
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "version"); }
        init { JsonModel.Set(this._rawData, "version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Created;
        _ = this.Name;
        _ = this.Updated;
        _ = this.Published;
        this.Settings?.Validate();
        this.Snippets?.Validate();
        _ = this.Version;
    }

    public Brand() { }

    public Brand(Brand brand)
        : base(brand) { }

    public Brand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Brand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandFromRaw.FromRawUnchecked"/>
    public static Brand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandFromRaw : IFromRawJson<Brand>
{
    /// <inheritdoc/>
    public Brand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Brand.FromRawUnchecked(rawData);
}
