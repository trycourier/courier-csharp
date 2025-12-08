using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<BrandColors, BrandColorsFromRaw>))]
public sealed record class BrandColors : ModelBase
{
    public string? Primary
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "primary"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "primary", value);
        }
    }

    public string? Secondary
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "secondary"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "secondary", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandColors(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandColorsFromRaw.FromRawUnchecked"/>
    public static BrandColors FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandColorsFromRaw : IFromRaw<BrandColors>
{
    /// <inheritdoc/>
    public BrandColors FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandColors.FromRawUnchecked(rawData);
}
