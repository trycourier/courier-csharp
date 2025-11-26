using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<EmailHeader, EmailHeaderFromRaw>))]
public sealed record class EmailHeader : ModelBase
{
    public required Logo Logo
    {
        get
        {
            if (!this._rawData.TryGetValue("logo", out JsonElement element))
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
            this._rawData["logo"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? BarColor
    {
        get
        {
            if (!this._rawData.TryGetValue("barColor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["barColor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? InheritDefault
    {
        get
        {
            if (!this._rawData.TryGetValue("inheritDefault", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["inheritDefault"] = JsonSerializer.SerializeToElement(
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

    public EmailHeader(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailHeader(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static EmailHeader FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EmailHeader(Logo logo)
        : this()
    {
        this.Logo = logo;
    }
}

class EmailHeaderFromRaw : IFromRaw<EmailHeader>
{
    public EmailHeader FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EmailHeader.FromRawUnchecked(rawData);
}
