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
            if (!this._rawData.TryGetValue("footer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EmailFooter?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["footer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public EmailHead? Head
    {
        get
        {
            if (!this._rawData.TryGetValue("head", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EmailHead?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["head"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public EmailHeader? Header
    {
        get
        {
            if (!this._rawData.TryGetValue("header", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EmailHeader?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["header"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TemplateOverride? TemplateOverride
    {
        get
        {
            if (!this._rawData.TryGetValue("templateOverride", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<TemplateOverride?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["templateOverride"] = JsonSerializer.SerializeToElement(
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

    public BrandSettingsEmail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSettingsEmail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BrandSettingsEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

[JsonConverter(typeof(ModelConverter<TemplateOverride>))]
public sealed record class TemplateOverride : ModelBase, IFromRaw<TemplateOverride>
{
    public required bool Enabled
    {
        get
        {
            if (!this._rawData.TryGetValue("enabled", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'enabled' cannot be null",
                    new ArgumentOutOfRangeException("enabled", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? BackgroundColor
    {
        get
        {
            if (!this._rawData.TryGetValue("backgroundColor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["backgroundColor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? BlocksBackgroundColor
    {
        get
        {
            if (!this._rawData.TryGetValue("blocksBackgroundColor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["blocksBackgroundColor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Footer
    {
        get
        {
            if (!this._rawData.TryGetValue("footer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["footer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Head
    {
        get
        {
            if (!this._rawData.TryGetValue("head", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["head"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Header
    {
        get
        {
            if (!this._rawData.TryGetValue("header", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["header"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Width
    {
        get
        {
            if (!this._rawData.TryGetValue("width", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["width"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required BrandTemplate Mjml
    {
        get
        {
            if (!this._rawData.TryGetValue("mjml", out JsonElement element))
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
            this._rawData["mjml"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? FooterBackgroundColor
    {
        get
        {
            if (!this._rawData.TryGetValue("footerBackgroundColor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["footerBackgroundColor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? FooterFullWidth
    {
        get
        {
            if (!this._rawData.TryGetValue("footerFullWidth", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["footerFullWidth"] = JsonSerializer.SerializeToElement(
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

    public TemplateOverride(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateOverride(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static TemplateOverride FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
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
            if (!this._rawData.TryGetValue("mjml", out JsonElement element))
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
            this._rawData["mjml"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? FooterBackgroundColor
    {
        get
        {
            if (!this._rawData.TryGetValue("footerBackgroundColor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["footerBackgroundColor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? FooterFullWidth
    {
        get
        {
            if (!this._rawData.TryGetValue("footerFullWidth", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["footerFullWidth"] = JsonSerializer.SerializeToElement(
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

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Courier.Models.Brands.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntersectionMember1(BrandTemplate mjml)
        : this()
    {
        this.Mjml = mjml;
    }
}
