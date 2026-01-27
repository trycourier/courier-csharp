using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandSettingsEmail, BrandSettingsEmailFromRaw>))]
public sealed record class BrandSettingsEmail : JsonModel
{
    public EmailFooter? Footer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmailFooter>("footer");
        }
        init { this._rawData.Set("footer", value); }
    }

    public EmailHead? Head
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmailHead>("head");
        }
        init { this._rawData.Set("head", value); }
    }

    public EmailHeader? Header
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmailHeader>("header");
        }
        init { this._rawData.Set("header", value); }
    }

    public TemplateOverride? TemplateOverride
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateOverride>("templateOverride");
        }
        init { this._rawData.Set("templateOverride", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Footer?.Validate();
        this.Head?.Validate();
        this.Header?.Validate();
        this.TemplateOverride?.Validate();
    }

    public BrandSettingsEmail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandSettingsEmail(BrandSettingsEmail brandSettingsEmail)
        : base(brandSettingsEmail) { }
#pragma warning restore CS8618

    public BrandSettingsEmail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSettingsEmail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandSettingsEmailFromRaw.FromRawUnchecked"/>
    public static BrandSettingsEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandSettingsEmailFromRaw : IFromRawJson<BrandSettingsEmail>
{
    /// <inheritdoc/>
    public BrandSettingsEmail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandSettingsEmail.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TemplateOverride, TemplateOverrideFromRaw>))]
public sealed record class TemplateOverride : JsonModel
{
    public required bool Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    public string? BackgroundColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("backgroundColor");
        }
        init { this._rawData.Set("backgroundColor", value); }
    }

    public string? BlocksBackgroundColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("blocksBackgroundColor");
        }
        init { this._rawData.Set("blocksBackgroundColor", value); }
    }

    public string? Footer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("footer");
        }
        init { this._rawData.Set("footer", value); }
    }

    public string? Head
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("head");
        }
        init { this._rawData.Set("head", value); }
    }

    public string? Header
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("header");
        }
        init { this._rawData.Set("header", value); }
    }

    public string? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("width");
        }
        init { this._rawData.Set("width", value); }
    }

    public required BrandTemplate Mjml
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BrandTemplate>("mjml");
        }
        init { this._rawData.Set("mjml", value); }
    }

    public string? FooterBackgroundColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("footerBackgroundColor");
        }
        init { this._rawData.Set("footerBackgroundColor", value); }
    }

    public bool? FooterFullWidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("footerFullWidth");
        }
        init { this._rawData.Set("footerFullWidth", value); }
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

    /// <inheritdoc/>
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateOverride(TemplateOverride templateOverride)
        : base(templateOverride) { }
#pragma warning restore CS8618

    public TemplateOverride(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateOverride(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateOverrideFromRaw.FromRawUnchecked"/>
    public static TemplateOverride FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateOverrideFromRaw : IFromRawJson<TemplateOverride>
{
    /// <inheritdoc/>
    public TemplateOverride FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplateOverride.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<IntersectionMember1, IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
    public required BrandTemplate Mjml
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BrandTemplate>("mjml");
        }
        init { this._rawData.Set("mjml", value); }
    }

    public string? FooterBackgroundColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("footerBackgroundColor");
        }
        init { this._rawData.Set("footerBackgroundColor", value); }
    }

    public bool? FooterFullWidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("footerFullWidth");
        }
        init { this._rawData.Set("footerFullWidth", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Mjml.Validate();
        _ = this.FooterBackgroundColor;
        _ = this.FooterFullWidth;
    }

    public IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember1(IntersectionMember1 intersectionMember1)
        : base(intersectionMember1) { }
#pragma warning restore CS8618

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static IntersectionMember1 FromRawUnchecked(
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

class IntersectionMember1FromRaw : IFromRawJson<IntersectionMember1>
{
    /// <inheritdoc/>
    public IntersectionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IntersectionMember1.FromRawUnchecked(rawData);
}
