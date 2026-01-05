using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandSettings, BrandSettingsFromRaw>))]
public sealed record class BrandSettings : JsonModel
{
    public BrandColors? Colors
    {
        get { return JsonModel.GetNullableClass<BrandColors>(this.RawData, "colors"); }
        init { JsonModel.Set(this._rawData, "colors", value); }
    }

    public BrandSettingsEmail? Email
    {
        get { return JsonModel.GetNullableClass<BrandSettingsEmail>(this.RawData, "email"); }
        init { JsonModel.Set(this._rawData, "email", value); }
    }

    public BrandSettingsInApp? Inapp
    {
        get { return JsonModel.GetNullableClass<BrandSettingsInApp>(this.RawData, "inapp"); }
        init { JsonModel.Set(this._rawData, "inapp", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Colors?.Validate();
        this.Email?.Validate();
        this.Inapp?.Validate();
    }

    public BrandSettings() { }

    public BrandSettings(BrandSettings brandSettings)
        : base(brandSettings) { }

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

    /// <inheritdoc cref="BrandSettingsFromRaw.FromRawUnchecked"/>
    public static BrandSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandSettingsFromRaw : IFromRawJson<BrandSettings>
{
    /// <inheritdoc/>
    public BrandSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandSettings.FromRawUnchecked(rawData);
}
