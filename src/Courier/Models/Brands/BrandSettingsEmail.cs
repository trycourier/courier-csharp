using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<BrandSettingsEmail>))]
public sealed record class BrandSettingsEmail : ModelBase, IFromRaw<BrandSettingsEmail>
{
    public EmailFooter? Footer
    {
        get
        {
            if (!this._properties.TryGetValue("footer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EmailFooter?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["footer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public EmailHead? Head
    {
        get
        {
            if (!this._properties.TryGetValue("head", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EmailHead?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["head"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public EmailHeader? Header
    {
        get
        {
            if (!this._properties.TryGetValue("header", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EmailHeader?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["header"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TemplateOverride? TemplateOverride
    {
        get
        {
            if (!this._properties.TryGetValue("templateOverride", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<TemplateOverride?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["templateOverride"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Footer?.Validate();
        this.Head?.Validate();
        this.Header?.Validate();
        this.TemplateOverride?.Validate();
    }

    public BrandSettingsEmail() { }

    public BrandSettingsEmail(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSettingsEmail(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BrandSettingsEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<TemplateOverride>))]
public sealed record class TemplateOverride : ModelBase, IFromRaw<TemplateOverride>
{
    public required bool Enabled
    {
        get
        {
            if (!this._properties.TryGetValue("enabled", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'enabled' cannot be null",
                    new ArgumentOutOfRangeException("enabled", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? BackgroundColor
    {
        get
        {
            if (!this._properties.TryGetValue("backgroundColor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["backgroundColor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? BlocksBackgroundColor
    {
        get
        {
            if (!this._properties.TryGetValue("blocksBackgroundColor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["blocksBackgroundColor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Footer
    {
        get
        {
            if (!this._properties.TryGetValue("footer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["footer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Head
    {
        get
        {
            if (!this._properties.TryGetValue("head", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["head"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Header
    {
        get
        {
            if (!this._properties.TryGetValue("header", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["header"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Width
    {
        get
        {
            if (!this._properties.TryGetValue("width", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["width"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required BrandTemplate Mjml
    {
        get
        {
            if (!this._properties.TryGetValue("mjml", out JsonElement element))
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
        init
        {
            this._properties["mjml"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? FooterBackgroundColor
    {
        get
        {
            if (!this._properties.TryGetValue("footerBackgroundColor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["footerBackgroundColor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? FooterFullWidth
    {
        get
        {
            if (!this._properties.TryGetValue("footerFullWidth", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["footerFullWidth"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator BrandTemplate(TemplateOverride templateOverride) =>
        new()
        {
            Enabled = templateOverride.Enabled,
            BackgroundColor = templateOverride.BackgroundColor,
            BlocksBackgroundColor = templateOverride.BlocksBackgroundColor,
            Footer = templateOverride.Footer,
            Head = templateOverride.Head,
            Header = templateOverride.Header,
            Width = templateOverride.Width,
        };

    public override void Validate()
    {
        _ = this.Enabled;
        _ = this.BackgroundColor;
        _ = this.BlocksBackgroundColor;
        _ = this.Footer;
        _ = this.Head;
        _ = this.Header;
        _ = this.Width;
        this.Mjml.Validate();
        _ = this.FooterBackgroundColor;
        _ = this.FooterFullWidth;
    }

    public TemplateOverride() { }

    public TemplateOverride(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateOverride(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static TemplateOverride FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<global::Courier.Models.Brands.IntersectionMember1>))]
public sealed record class IntersectionMember1
    : ModelBase,
        IFromRaw<global::Courier.Models.Brands.IntersectionMember1>
{
    public required BrandTemplate Mjml
    {
        get
        {
            if (!this._properties.TryGetValue("mjml", out JsonElement element))
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
        init
        {
            this._properties["mjml"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? FooterBackgroundColor
    {
        get
        {
            if (!this._properties.TryGetValue("footerBackgroundColor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["footerBackgroundColor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? FooterFullWidth
    {
        get
        {
            if (!this._properties.TryGetValue("footerFullWidth", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["footerFullWidth"] = JsonSerializer.SerializeToElement(
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

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Courier.Models.Brands.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public IntersectionMember1(BrandTemplate mjml)
        : this()
    {
        this.Mjml = mjml;
    }
}
