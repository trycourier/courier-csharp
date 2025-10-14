using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<EmailHeader>))]
public sealed record class EmailHeader : ModelBase, IFromRaw<EmailHeader>
{
    public required Logo Logo
    {
        get
        {
            if (!this.Properties.TryGetValue("logo", out JsonElement element))
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
        set
        {
            this.Properties["logo"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? BarColor
    {
        get
        {
            if (!this.Properties.TryGetValue("barColor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["barColor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? InheritDefault
    {
        get
        {
            if (!this.Properties.TryGetValue("inheritDefault", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["inheritDefault"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailHeader(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static EmailHeader FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public EmailHeader(Logo logo)
        : this()
    {
        this.Logo = logo;
    }
}
