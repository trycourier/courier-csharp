using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandTemplate, BrandTemplateFromRaw>))]
public sealed record class BrandTemplate : JsonModel
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandTemplate(BrandTemplate brandTemplate)
        : base(brandTemplate) { }
#pragma warning restore CS8618

    public BrandTemplate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandTemplate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class BrandTemplateFromRaw : IFromRawJson<BrandTemplate>
{
    /// <inheritdoc/>
    public BrandTemplate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandTemplate.FromRawUnchecked(rawData);
}
