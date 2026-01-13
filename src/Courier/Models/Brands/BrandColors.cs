using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandColors, BrandColorsFromRaw>))]
public sealed record class BrandColors : JsonModel
{
    public string? Primary
    {
        get { return this._rawData.GetNullableClass<string>("primary"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("primary", value);
        }
    }

    public string? Secondary
    {
        get { return this._rawData.GetNullableClass<string>("secondary"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("secondary", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Primary;
        _ = this.Secondary;
    }

    public BrandColors() { }

    public BrandColors(BrandColors brandColors)
        : base(brandColors) { }

    public BrandColors(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandColors(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandColorsFromRaw.FromRawUnchecked"/>
    public static BrandColors FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandColorsFromRaw : IFromRawJson<BrandColors>
{
    /// <inheritdoc/>
    public BrandColors FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandColors.FromRawUnchecked(rawData);
}
