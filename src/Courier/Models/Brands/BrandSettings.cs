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
        get
        {
            if (!this._rawData.TryGetValue("colors", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BrandColors?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["colors"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BrandSettingsEmail? Email
    {
        get
        {
            if (!this._rawData.TryGetValue("email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BrandSettingsEmail?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BrandSettingsInApp? Inapp
    {
        get
        {
            if (!this._rawData.TryGetValue("inapp", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BrandSettingsInApp?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["inapp"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
