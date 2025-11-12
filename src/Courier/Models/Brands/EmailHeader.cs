using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<EmailHeader>))]
public sealed record class EmailHeader : ModelBase, IFromRaw<EmailHeader>
{
    public required Logo Logo
    {
        get
        {
            if (!this._properties.TryGetValue("logo", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'logo' cannot be null",
                    new ArgumentOutOfRangeException("logo", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Logo>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'logo' cannot be null",
                    new ArgumentNullException("logo")
                );
        }
        init
        {
            this._properties["logo"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? BarColor
    {
        get
        {
            if (!this._properties.TryGetValue("barColor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["barColor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? InheritDefault
    {
        get
        {
            if (!this._properties.TryGetValue("inheritDefault", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["inheritDefault"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Logo.Validate();
        _ = this.BarColor;
        _ = this.InheritDefault;
    }

    public EmailHeader() { }

    public EmailHeader(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailHeader(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static EmailHeader FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public EmailHeader(Logo logo)
        : this()
    {
        this.Logo = logo;
    }
}
