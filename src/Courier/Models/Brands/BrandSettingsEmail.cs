using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<BrandSettingsEmail, BrandSettingsEmailFromRaw>))]
public sealed record class BrandSettingsEmail : ModelBase
{
    public EmailFooter? Footer
    {
        get { return ModelBase.GetNullableClass<EmailFooter>(this.RawData, "footer"); }
        init { ModelBase.Set(this._rawData, "footer", value); }
    }

    public EmailHead? Head
    {
        get { return ModelBase.GetNullableClass<EmailHead>(this.RawData, "head"); }
        init { ModelBase.Set(this._rawData, "head", value); }
    }

    public EmailHeader? Header
    {
        get { return ModelBase.GetNullableClass<EmailHeader>(this.RawData, "header"); }
        init { ModelBase.Set(this._rawData, "header", value); }
    }

    public TemplateOverride? TemplateOverride
    {
        get
        {
            return ModelBase.GetNullableClass<TemplateOverride>(this.RawData, "templateOverride");
        }
        init { ModelBase.Set(this._rawData, "templateOverride", value); }
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

    /// <inheritdoc cref="BrandSettingsEmailFromRaw.FromRawUnchecked"/>
    public static BrandSettingsEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandSettingsEmailFromRaw : IFromRaw<BrandSettingsEmail>
{
    /// <inheritdoc/>
    public BrandSettingsEmail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandSettingsEmail.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<TemplateOverride, TemplateOverrideFromRaw>))]
public sealed record class TemplateOverride : ModelBase
{
    public required bool Enabled
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "enabled"); }
        init { ModelBase.Set(this._rawData, "enabled", value); }
    }

    public string? BackgroundColor
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "backgroundColor"); }
        init { ModelBase.Set(this._rawData, "backgroundColor", value); }
    }

    public string? BlocksBackgroundColor
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "blocksBackgroundColor"); }
        init { ModelBase.Set(this._rawData, "blocksBackgroundColor", value); }
    }

    public string? Footer
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "footer"); }
        init { ModelBase.Set(this._rawData, "footer", value); }
    }

    public string? Head
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "head"); }
        init { ModelBase.Set(this._rawData, "head", value); }
    }

    public string? Header
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "header"); }
        init { ModelBase.Set(this._rawData, "header", value); }
    }

    public string? Width
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "width"); }
        init { ModelBase.Set(this._rawData, "width", value); }
    }

    public required BrandTemplate Mjml
    {
        get { return ModelBase.GetNotNullClass<BrandTemplate>(this.RawData, "mjml"); }
        init { ModelBase.Set(this._rawData, "mjml", value); }
    }

    public string? FooterBackgroundColor
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "footerBackgroundColor"); }
        init { ModelBase.Set(this._rawData, "footerBackgroundColor", value); }
    }

    public bool? FooterFullWidth
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "footerFullWidth"); }
        init { ModelBase.Set(this._rawData, "footerFullWidth", value); }
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

    /// <inheritdoc cref="TemplateOverrideFromRaw.FromRawUnchecked"/>
    public static TemplateOverride FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateOverrideFromRaw : IFromRaw<TemplateOverride>
{
    /// <inheritdoc/>
    public TemplateOverride FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplateOverride.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        global::Courier.Models.Brands.IntersectionMember1,
        global::Courier.Models.Brands.IntersectionMember1FromRaw
    >)
)]
public sealed record class IntersectionMember1 : ModelBase
{
    public required BrandTemplate Mjml
    {
        get { return ModelBase.GetNotNullClass<BrandTemplate>(this.RawData, "mjml"); }
        init { ModelBase.Set(this._rawData, "mjml", value); }
    }

    public string? FooterBackgroundColor
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "footerBackgroundColor"); }
        init { ModelBase.Set(this._rawData, "footerBackgroundColor", value); }
    }

    public bool? FooterFullWidth
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "footerFullWidth"); }
        init { ModelBase.Set(this._rawData, "footerFullWidth", value); }
    }

    /// <inheritdoc/>
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

class IntersectionMember1FromRaw : IFromRaw<global::Courier.Models.Brands.IntersectionMember1>
{
    /// <inheritdoc/>
    public global::Courier.Models.Brands.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Courier.Models.Brands.IntersectionMember1.FromRawUnchecked(rawData);
}
