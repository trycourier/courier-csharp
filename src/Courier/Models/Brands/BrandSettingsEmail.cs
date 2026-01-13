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
        get { return this._rawData.GetNullableClass<EmailFooter>("footer"); }
        init { this._rawData.Set("footer", value); }
    }

    public EmailHead? Head
    {
        get { return this._rawData.GetNullableClass<EmailHead>("head"); }
        init { this._rawData.Set("head", value); }
    }

    public EmailHeader? Header
    {
        get { return this._rawData.GetNullableClass<EmailHeader>("header"); }
        init { this._rawData.Set("header", value); }
    }

    public TemplateOverride? TemplateOverride
    {
        get { return this._rawData.GetNullableClass<TemplateOverride>("templateOverride"); }
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

    public BrandSettingsEmail(BrandSettingsEmail brandSettingsEmail)
        : base(brandSettingsEmail) { }

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
        get { return this._rawData.GetNotNullStruct<bool>("enabled"); }
        init { this._rawData.Set("enabled", value); }
    }

    public string? BackgroundColor
    {
        get { return this._rawData.GetNullableClass<string>("backgroundColor"); }
        init { this._rawData.Set("backgroundColor", value); }
    }

    public string? BlocksBackgroundColor
    {
        get { return this._rawData.GetNullableClass<string>("blocksBackgroundColor"); }
        init { this._rawData.Set("blocksBackgroundColor", value); }
    }

    public string? Footer
    {
        get { return this._rawData.GetNullableClass<string>("footer"); }
        init { this._rawData.Set("footer", value); }
    }

    public string? Head
    {
        get { return this._rawData.GetNullableClass<string>("head"); }
        init { this._rawData.Set("head", value); }
    }

    public string? Header
    {
        get { return this._rawData.GetNullableClass<string>("header"); }
        init { this._rawData.Set("header", value); }
    }

    public string? Width
    {
        get { return this._rawData.GetNullableClass<string>("width"); }
        init { this._rawData.Set("width", value); }
    }

    public required BrandTemplate Mjml
    {
        get { return this._rawData.GetNotNullClass<BrandTemplate>("mjml"); }
        init { this._rawData.Set("mjml", value); }
    }

    public string? FooterBackgroundColor
    {
        get { return this._rawData.GetNullableClass<string>("footerBackgroundColor"); }
        init { this._rawData.Set("footerBackgroundColor", value); }
    }

    public bool? FooterFullWidth
    {
        get { return this._rawData.GetNullableStruct<bool>("footerFullWidth"); }
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

    public TemplateOverride(TemplateOverride templateOverride)
        : base(templateOverride) { }

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

[JsonConverter(
    typeof(JsonModelConverter<
        global::Courier.Models.Brands.IntersectionMember1,
        global::Courier.Models.Brands.IntersectionMember1FromRaw
    >)
)]
public sealed record class IntersectionMember1 : JsonModel
{
    public required BrandTemplate Mjml
    {
        get { return this._rawData.GetNotNullClass<BrandTemplate>("mjml"); }
        init { this._rawData.Set("mjml", value); }
    }

    public string? FooterBackgroundColor
    {
        get { return this._rawData.GetNullableClass<string>("footerBackgroundColor"); }
        init { this._rawData.Set("footerBackgroundColor", value); }
    }

    public bool? FooterFullWidth
    {
        get { return this._rawData.GetNullableStruct<bool>("footerFullWidth"); }
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

    public IntersectionMember1(
        global::Courier.Models.Brands.IntersectionMember1 intersectionMember1
    )
        : base(intersectionMember1) { }

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

    /// <inheritdoc cref="global::Courier.Models.Brands.IntersectionMember1FromRaw.FromRawUnchecked"/>
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

class IntersectionMember1FromRaw : IFromRawJson<global::Courier.Models.Brands.IntersectionMember1>
{
    /// <inheritdoc/>
    public global::Courier.Models.Brands.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Courier.Models.Brands.IntersectionMember1.FromRawUnchecked(rawData);
}
