using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<Brand, BrandFromRaw>))]
public sealed record class Brand : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required long Created
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "created"); }
        init { ModelBase.Set(this._rawData, "created", value); }
    }

    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public required long Updated
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "updated"); }
        init { ModelBase.Set(this._rawData, "updated", value); }
    }

    public long? Published
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "published"); }
        init { ModelBase.Set(this._rawData, "published", value); }
    }

    public BrandSettings? Settings
    {
        get { return ModelBase.GetNullableClass<BrandSettings>(this.RawData, "settings"); }
        init { ModelBase.Set(this._rawData, "settings", value); }
    }

    public BrandSnippets? Snippets
    {
        get { return ModelBase.GetNullableClass<BrandSnippets>(this.RawData, "snippets"); }
        init { ModelBase.Set(this._rawData, "snippets", value); }
    }

    public string? Version
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "version"); }
        init { ModelBase.Set(this._rawData, "version", value); }
    }

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

    public static Brand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandFromRaw : IFromRaw<Brand>
{
    public Brand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Brand.FromRawUnchecked(rawData);
}
