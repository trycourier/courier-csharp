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
            if (!this.Properties.TryGetValue("colors", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BrandColors?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["colors"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BrandSettingsEmail? Email
    {
        get
        {
            if (!this.Properties.TryGetValue("email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BrandSettingsEmail?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BrandSettingsInApp? Inapp
    {
        get
        {
            if (!this.Properties.TryGetValue("inapp", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BrandSettingsInApp?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["inapp"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSettings(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BrandSettings FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
