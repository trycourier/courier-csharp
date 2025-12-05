using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<BrandTemplate, BrandTemplateFromRaw>))]
public sealed record class BrandTemplate : ModelBase
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
    }

    public BrandTemplate() { }

    public BrandTemplate(BrandTemplate brandTemplate)
        : base(brandTemplate) { }

    public BrandTemplate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandTemplate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandTemplateFromRaw.FromRawUnchecked"/>
    public static BrandTemplate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrandTemplate(bool enabled)
        : this()
    {
        this.Enabled = enabled;
    }
}

class BrandTemplateFromRaw : IFromRaw<BrandTemplate>
{
    /// <inheritdoc/>
    public BrandTemplate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandTemplate.FromRawUnchecked(rawData);
}
