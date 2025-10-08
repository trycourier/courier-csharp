using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.BrandSettingsEmailProperties.TemplateOverrideProperties;

[JsonConverter(typeof(ModelConverter<IntersectionMember1>))]
public sealed record class IntersectionMember1 : ModelBase, IFromRaw<IntersectionMember1>
{
    public required BrandTemplate Mjml
    {
        get
        {
            if (!this.Properties.TryGetValue("mjml", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'mjml' cannot be null",
                    new ArgumentOutOfRangeException("mjml", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BrandTemplate>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'mjml' cannot be null",
                    new ArgumentNullException("mjml")
                );
        }
        set
        {
            this.Properties["mjml"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? FooterBackgroundColor
    {
        get
        {
            if (!this.Properties.TryGetValue("footerBackgroundColor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["footerBackgroundColor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? FooterFullWidth
    {
        get
        {
            if (!this.Properties.TryGetValue("footerFullWidth", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["footerFullWidth"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Mjml.Validate();
        _ = this.FooterBackgroundColor;
        _ = this.FooterFullWidth;
    }

    public IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static IntersectionMember1 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public IntersectionMember1(BrandTemplate mjml)
        : this()
    {
        this.Mjml = mjml;
    }
}
