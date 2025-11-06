using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<BrandSettings>))]
public sealed record class BrandSettings : ModelBase, IFromRaw<BrandSettings>
{
    public BrandColors? Colors
    {
        get
        {
            if (!this._properties.TryGetValue("colors", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BrandColors?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["colors"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BrandSettingsEmail? Email
    {
        get
        {
            if (!this._properties.TryGetValue("email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BrandSettingsEmail?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BrandSettingsInApp? Inapp
    {
        get
        {
            if (!this._properties.TryGetValue("inapp", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BrandSettingsInApp?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["inapp"] = JsonSerializer.SerializeToElement(
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

    public BrandSettings(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSettings(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BrandSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
