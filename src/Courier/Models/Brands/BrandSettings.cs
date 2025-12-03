using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<BrandSettings, BrandSettingsFromRaw>))]
public sealed record class BrandSettings : ModelBase
{
    public BrandColors? Colors
    {
        get { return ModelBase.GetNullableClass<BrandColors>(this.RawData, "colors"); }
        init { ModelBase.Set(this._rawData, "colors", value); }
    }

    public BrandSettingsEmail? Email
    {
        get { return ModelBase.GetNullableClass<BrandSettingsEmail>(this.RawData, "email"); }
        init { ModelBase.Set(this._rawData, "email", value); }
    }

    public BrandSettingsInApp? Inapp
    {
        get { return ModelBase.GetNullableClass<BrandSettingsInApp>(this.RawData, "inapp"); }
        init { ModelBase.Set(this._rawData, "inapp", value); }
    }

    public override void Validate()
    {
        this.Colors?.Validate();
        this.Email?.Validate();
        this.Inapp?.Validate();
    }

    public BrandSettings() { }

    public BrandSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BrandSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandSettingsFromRaw : IFromRaw<BrandSettings>
{
    public BrandSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandSettings.FromRawUnchecked(rawData);
}
