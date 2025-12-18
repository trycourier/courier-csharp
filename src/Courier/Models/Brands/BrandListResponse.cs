using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandListResponse, BrandListResponseFromRaw>))]
public sealed record class BrandListResponse : JsonModel
{
    public required Paging Paging
    {
        get { return JsonModel.GetNotNullClass<Paging>(this.RawData, "paging"); }
        init { JsonModel.Set(this._rawData, "paging", value); }
    }

    public required IReadOnlyList<Brand> Results
    {
        get { return JsonModel.GetNotNullClass<List<Brand>>(this.RawData, "results"); }
        init { JsonModel.Set(this._rawData, "results", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Paging.Validate();
        foreach (var item in this.Results)
        {
            item.Validate();
        }
    }

    public BrandListResponse() { }

    public BrandListResponse(BrandListResponse brandListResponse)
        : base(brandListResponse) { }

    public BrandListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandListResponseFromRaw.FromRawUnchecked"/>
    public static BrandListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandListResponseFromRaw : IFromRawJson<BrandListResponse>
{
    /// <inheritdoc/>
    public BrandListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandListResponse.FromRawUnchecked(rawData);
}
